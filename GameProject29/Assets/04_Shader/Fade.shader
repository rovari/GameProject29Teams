Shader "Custom/Fade"
{
    Properties
    {
		[KeywordEnum(DEFAULT, MASK)]
		_TYPE	("Fade Type" , int)	= 0

		[HideInInspector] _MainTex	("Albedo (RGB)"	, 2D)	= "white" {}
						  _Mask		("Mask"			, 2D)	= "white" {}
		[Toggle]		  _Reverse	("Reverse Mask ", int)	= 0
		[Toggle]		  _Link		("Color Link "	, int)	= 0

		_Color	("Color"	, Color)						= (0, 0, 0, 0)
		_SubCol	("SubColor"	, Color)						= (0, 0, 0, 0)
		_Range	("Level"	, Range(0.0 , 1.0))				= 0.0
    }
    SubShader
	{
		Pass
		{
		    Tags {"RenderType" = "Fade"}
			Blend	SrcAlpha OneMinusSrcAlpha
			ZTest	Off
			ZWrite	Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma shader_feature _TYPE_DEFAULT _TYPE_MASK
			#include "UnityCG.cginc"

			sampler2D	_MainTex;
			sampler2D	_Mask;
            float4		_MainTex_ST;

	        struct appdata {
                float4 vertex	: POSITION;
                float2 uv		: TEXCOORD0;
            };

			struct v2f {
				float2 uv		: TEXCOORD0;
				float4 vertex	: SV_POSITION;
			};

            v2f vert (appdata v) {
                v2f o;
                o.vertex	= UnityObjectToClipPos(v.vertex);
                o.uv		= TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

			int	_Reverse;
			int	_Link;

			fixed	_Range;
			fixed4	_Color;
			fixed4	_SubCol;

			fixed4 frag(v2f i) : SV_Target {

				fixed4 c = tex2D(_MainTex, i.uv);
				
				#ifdef _TYPE_DEFAULT
				c.a		= _Range;

				#elif  _TYPE_MASK
				c.a = (_Reverse == 0)
					? (tex2D(_Mask, i.uv).r		  <= _Range) ? 1.0 : 0.0
					: (1.0 - tex2D(_Mask, i.uv).r <  _Range) ? 1.0 : 0.0;

				#endif

				c.rgb *= (_Link == 0) ? _Color.rgb : lerp(_Color, _SubCol, _Range);
				
				return c;
			}
			ENDCG
		}
	}
}
