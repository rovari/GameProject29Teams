Shader "Custom/Surface"
{
    Properties
    {
		[KeywordEnum(ONECOLOR, LAMBERT, CEL, UV, HEIGHT)]
		_GT ("Gradation Type", float) = 0

		_MainTex ("Albedo (RGB)", 2D)				= "white" {}
		_BumpMap ("Normal Map"	, 2D)				= "bump"  {}
		
        _Color		("Color"					, Color)			= (1,1,1,1)
        _SubColor	("Sub Color"				, Color)			= (1,1,1,1)
        _Height		("Normal Level"				, Range(0, 2.0))	= 1.0
		_Clv		("Cel Light Level"			, Range(0.0, 1.0))	= 0.5
		_GV_X		("Gradation UV vector X"	, Range(0.0, 1.0))	= 1.0
		_GV_Y		("Gradation UV vector Y"	, Range(0.0, 1.0))	= 1.0
		_GH_TOP		("Gradation Height Top"		, float)			= 0
		_GH_BOTTOM	("Gradation Height Bottom"	, float)			= 0

		_Mask		("Dissolve Mask", 2D)			= "white" {}
		[Toggle]	_Reverse("Reverse Mask "	, int)				= 0
		_Range		("Dissolve"					, Range(0.0 , 1.0))	= 0.0
        _DisCol		("Dissolve Color"			, Color)			= (1,1,1,1)
        _DisEdgeCol	("Dissolve Edge Color"		, Color)			= (1,1,1,1)
		_Scr_X		("UvScroll Speed X"			, float)			= 0.0			
		_Scr_Y		("UvScroll Speed Y"			, float)			= 0.0

		[Toggle]		_Fog	("Fog"			, int)				= 0
        _FogStart	("Fog Start"				, float)			= 0
        _FogEnd		("Fog End"					, float)			= 0
		_FogColor	("Fog Color"				, Color)			= (1,1,1,1)

		[Toggle]		_Rim	("Rim"			, int)				= 0
		_RimLv		("Rim Level"				, Range(0.0, 10.0))	= 0
		_RimColor	("Rim Color"				, Color)			= (1,1,1,1)

		[HideInInspector]
		_Discard	("Discard"					, int)				= 0
    }
    SubShader
    {
        LOD		200
		ZWrite	On
		Cull	Off
		Tags {"Queue" = "AlphaTest"}

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert
        #pragma target 4.0
		#pragma shader_feature _GT_ONECOLOR _GT_LAMBERT _GT_CEL _GT_UV _GT_HEIGHT

        sampler2D _MainTex;
		sampler2D _BumpMap;
		sampler2D _Mask;
		
        struct Input{
            float2	uv_MainTex;
            float2	uv_BumpMap;
            float2	uv_Mask;
			float3	worldPos;
			float3	lightDir;
			float3	viewDir;
        };

        fixed4	_Color, _SubColor, _FogColor, _RimColor, _DisCol, _DisEdgeCol;
		fixed	_Height, _Clv, _RimLv;
		fixed	_GV_X, _GV_Y, _GH_TOP, _GH_BOTTOM;
		int		_Reverse, _Fog, _Rim;
		fixed	_Range;
		float	_Scr_X, _Scr_Y, _FogStart, _FogEnd;
		int		_Discard;

		float Gradation_Vec		(float2 uv)			{ return length(uv * float2( _GV_X, _GV_Y)); }
		float Gradation_Height	(float	y)			{ return saturate((y) / (_GH_TOP - _GH_BOTTOM)); }
		float Gradation_Lambert	(float3 n, float3 l){ return dot(n, l); }

		void vert(inout appdata_full v, out Input o) {

			UNITY_INITIALIZE_OUTPUT(Input, o);

			TANGENT_SPACE_ROTATION;
			o.lightDir = normalize(mul(rotation, mul(unity_WorldToObject, -float3(1.0, -1.0, 1.0))));
		}

		void Dissolve(float2 uv) {
			fixed m = tex2D(_Mask, uv).r;
			m = (_Reverse != 0) ? 1.0 - m : m;

			if (m < _Range) { _Discard = true; }
		}

        void surf (Input IN, inout SurfaceOutput o) {

			float2 addUv = float2(_Time.y * _Scr_X, _Time.y * _Scr_Y);

			fixed4	c	= tex2D(_MainTex, IN.uv_MainTex + addUv);
			float3	n	= UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap + addUv) * _Height);
			float3	l	= normalize(float3(1.0, -1.0, 1.0));

			Dissolve(IN.uv_Mask + addUv);
			if (c.a < 1.0 || _Discard) discard;

			#ifdef _GT_ONECOLOR
			c = c * _Color;

			#elif _GT_UV
            c = saturate(c * lerp(_SubColor, _Color, Gradation_Vec(IN.uv_MainTex)));

			#elif  _GT_HEIGHT
			c = saturate(c * lerp(_SubColor, _Color, Gradation_Height(IN.worldPos.y)));

			#elif  _GT_LAMBERT
			c = saturate(c * lerp(_SubColor, _Color, max(0, Gradation_Lambert(n, normalize(IN.lightDir)))));

			#elif  _GT_CEL
			c = saturate(c * (Gradation_Lambert(n, normalize(IN.lightDir)) < _Clv * 2.0 - 1.0 ? _SubColor : _Color ));

            #endif

			if (_Fog != 0) {

				float linerDep	= 1.0 / (30.0 - 0.1);
				float linerPos	= length(_WorldSpaceCameraPos - IN.worldPos) * linerDep;
				float fogFactor = saturate((_FogEnd - linerPos) / (_FogEnd - _FogStart));

				c = saturate(lerp(_FogColor * c, c, pow(fogFactor, 10)));
			}

			if (_Rim != 0) {
				fixed4 rim = _RimColor * (1.0 - saturate(dot(IN.viewDir, n)));
				c += pow(rim, _RimLv);
			}


			o.Normal = n;
			o.Albedo = lerp(c, _DisCol, _Range * _Range);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
