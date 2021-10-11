Shader "Custom/Output" {

    Properties  {

        _MainTex ("Texture"	, 2D)				= "white" {}
		
		[Space(5)][Header(Chromatic Aberration)][Space(10)]
		[Toggle]
		_CA		 ("Active"			, int)				= 0
		_CALv	 ("CA Level"		, Range(0.0, 1.0))	= 0.0

		[Space(5)][Header(Fill)][Space(10)]
		[Toggle]
		_Fill	 ("Active"			, int)				= 0
		_FiCol	 ("Fill Color"		, Color)			= (1,1,1,1)
		_FiLv	 ("Fill Level"		, Range(0.0, 1.0))	= 0.0

		[Space(5)][Header(Laplasian)][Space(10)]
		[Toggle]
		_DFLAG	 ("Use Depth"		, int)				= 0
		_Color	 ("Line Color"		, Color)			= (1,1,1,1)
		_Thick	 ("Line Thick"		, Range(0.5, 5.0))	= 1.0
		_CDIFF	 ("Color Differece"	, Range(0.0, 1.0))	= 0.00
		_NDIFF	 ("Normal Differece", Range(0.0, 1.0))	= 0.00
		_DDIFF	 ("Depth Differece"	, Range(0.0, 1.0))	= 0.00

		[Space(5)][Header(Vignette)][Space(10)]
		[Toggle]
		_Vig	 ("Active"			, int)				= 0
		_ViCol	 ("Vignette Color"	, Color)			= (0,0,0,0)
		_ViLv	 ("Vignette Level"	, Range(0.0, 1.0))	= 0.0
		_ViRg	 ("Vignette Range"	, Range(0.0, 1.0))	= 0.0

		[Space(5)][Header(Fade)][Space(10)]
		[KeywordEnum(COLOR, MASK, COLORMASK)]
		_TYPE	 ("Fade Type"		, int)				= 0
		_FadeMask("Fade Mask"		, 2D)				= "white" {}
		[Toggle]		  
		_Reverse ("Reverse Mask"	, int)				= 0
		_FdCol	 ("Fade Color"		, Color)			= (0, 0, 0, 0)
		_FdRange ("Level"			, Range(0.0 , 1.0))	= 0.0
    }

    SubShader {

        Cull	Off
		ZWrite	Off
		ZTest	Always

        Pass {
            CGPROGRAM
            #pragma vertex	 vert
            #pragma fragment frag
			#pragma shader_feature _TYPE_COLOR _TYPE_MASK _TYPE_COLORMASK

            #include "UnityCG.cginc"
			#include "UnityGBuffer.cginc"

            struct appdata {

                float4 vertex	: POSITION;
                float2 uv		: TEXCOORD0;
            };
            struct v2f {

                float2 uv		: TEXCOORD0;
                float4 vertex	: SV_POSITION;
            };

            sampler2D _MainTex;
			sampler2D _FadeMask;
			sampler2D _CameraGBufferTexture0;
			sampler2D _CameraGBufferTexture2;
			sampler2D _CameraDepthTexture;

			int		_Fill;
			fixed	_FiLv;
			fixed4	_FiCol;

			int		_CA;
			fixed	_CALv;

			int		_DFLAG;
			fixed	_Thick, _CDIFF, _NDIFF, _DDIFF;
			fixed4	_Color;

			int		_Vig;
			fixed	_ViLv;
			fixed	_ViRg;
			fixed4	_ViCol;

			int		_Reverse;
			fixed	_FdRange;
			fixed4	_FdCol;

			fixed4 ChromaticAberration	(float2 uv, fixed4 col) {
				
				fixed4 c = col;

				half2	texCoord	= uv - 0.5;
				fixed2	rUv         = texCoord * (1.0 - _CALv * 0.1 * 2.0) + 0.5;
				fixed2	gUv         = texCoord * (1.0 - _CALv * 0.1) + 0.5;
				c.r					= tex2D(_CameraGBufferTexture0, rUv).r;
				c.g					= tex2D(_CameraGBufferTexture0, gUv).g;

				return c;
			}
			fixed4 Fill					(fixed4 col) {
				return lerp(col, _FiCol, _FiLv);
			}
			fixed4 Laplacian			(float2 uv, fixed4 col) {

				float3 c_diff ,n_diff;
				float  d_diff;

				c_diff = n_diff = d_diff = 0;
				
				float2	uvCrd = float2(_Thick / 1920, _Thick / 1080);

				float2 UV[9];
				UV[0] = uv;
				UV[1] = uv + float2(  uvCrd.x, -uvCrd.y);
				UV[2] = uv + float2(	  0.0, -uvCrd.y);
				UV[3] = uv + float2( -uvCrd.x, -uvCrd.y);
				UV[4] = uv + float2(  uvCrd.x,		0.0);
				UV[5] = uv + float2( -uvCrd.x,		0.0);
				UV[6] = uv + float2(  uvCrd.x,  uvCrd.y);
				UV[7] = uv + float2(	  0.0,  uvCrd.y);
				UV[8] = uv + float2( -uvCrd.x,  uvCrd.y);

				c_diff	+= tex2D(_CameraGBufferTexture0, UV[0]).rgb * -8.0;
				n_diff	+= tex2D(_CameraGBufferTexture2, UV[0]).rgb * -8.0;
				d_diff	+= Linear01Depth(tex2D(_CameraDepthTexture, UV[0]).r) * -8.0;

				[unroll]
				for (int i = 1; i < 9; ++i) {
					c_diff += tex2D(_CameraGBufferTexture0, UV[i]).rgb;
					n_diff += tex2D(_CameraGBufferTexture2, UV[i]).rgb;
					d_diff += Linear01Depth(tex2D(_CameraDepthTexture, UV[i]).r);
				}

				bool  df = (_DFLAG && (abs(d_diff) >= _DDIFF * 0.01)) ? true : false;
				fixed lp = (length(c_diff) * 2 >= _CDIFF || length(n_diff) >= _NDIFF || df) ? 1.0 : 0.0;

				return lerp(col ,lp * _Color, lp);
			}
			fixed4 Vignette				(float2 uv, fixed4 col) {

				float2 vig;
				vig.x = uv.x * 2.0 - 1.0;
				vig.y = (1.0 - uv.y) * 2.0 - 1.0;

				float ret = pow(1.0 - dot(vig, vig) * _ViRg, _ViLv * 100.0);

				return lerp(_ViCol, col, ret);
			}
			fixed4 Fade					(float2 uv, fixed4 col){

				fixed4 c;
				fixed  fr	= 0;
				
				#ifdef _TYPE_COLOR
				fr = _FdRange;

				#elif  _TYPE_MASK
				fr = (_Reverse)
					? (tex2D(_FadeMask, uv).r		<= _FdRange) ? 1.0: 0.0
					: (1.0 - tex2D(_FadeMask, uv).r <  _FdRange) ? 1.0: 0.0;
				
				#elif  _TYPE_COLORMASK
				fr = (_Reverse)
					? (tex2D(_FadeMask, uv).r		<= _FdRange) ? _FdRange : 0.0
					: (1.0 - tex2D(_FadeMask, uv).r <  _FdRange) ? _FdRange : 0.0;
				#endif

				c = lerp(col, _FdCol, fr);

				return c;
			}

            v2f		vert (appdata v) {
                v2f o;
                o.vertex	= UnityObjectToClipPos(v.vertex);
                o.uv		= v.uv;
                return o;
            }

            fixed4	frag (v2f i) : SV_Target {

                fixed4	col = tex2D(_MainTex, i.uv);
				
				col = (_CA)		? ChromaticAberration(i.uv, col) : col;
				col = (_Fill)	? Fill(col)	: col;
				col = Laplacian(i.uv, col);
				col = (_Vig) ? Vignette(i.uv, col) : col;
				col = Fade(i.uv, col);

				return col;
			}
			
            ENDCG
        }
    }
}
