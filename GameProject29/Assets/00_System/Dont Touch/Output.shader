Shader "Custom/Output"
{
    Properties
    {
        _MainTex ("Texture"	, 2D)				= "white" {}
		_Color	 ("Color"	, Color)			= (1,1,1,1)
		_Thick	 ("Thick"	, Range(0.5, 5.0))	= 1.0

		[Toggle]
		_DFLAG	 ("Use Depth"		, int)				= 0
		_CDIFF	 ("Color Differece"	, Range(0.0, 1.0))	= 0.00
		_NDIFF	 ("Normal Differece", Range(0.0, 1.0))	= 0.00
		_DDIFF	 ("Depth Differece"	, Range(0.0, 1.0))	= 0.00
    }
    SubShader
    {
        Cull	Off
		ZWrite	Off
		ZTest	Always

        Pass
        {
            CGPROGRAM
            #pragma vertex	 vert
            #pragma fragment frag

            #include "UnityCG.cginc"
			#include "UnityGBuffer.cginc"

			sampler2D _CameraGBufferTexture0;
			sampler2D _CameraGBufferTexture2;
			sampler2D _CameraDepthTexture;

            struct appdata
            {
                float4 vertex	: POSITION;
                float2 uv		: TEXCOORD0;
            };

            struct v2f
            {
                float2 uv		: TEXCOORD0;
                float4 vertex	: SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex	= UnityObjectToClipPos(v.vertex);
                o.uv		= v.uv;
                return o;
            }

			fixed4	_Color;
			fixed _Thick, _CDIFF, _NDIFF, _DDIFF;
			int	  _DFLAG;

			float  Laplacian(float2 uv) {

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

				bool df = (_DFLAG && (abs(d_diff) >= _DDIFF * 0.01)) ? true : false;

				return (length(c_diff) * 2 >= _CDIFF|| length(n_diff) >= _NDIFF || df) ? 1.0 : 0.0;
			}

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4	col = tex2D(_MainTex, i.uv);
				fixed	lp	= Laplacian(i.uv);

                return col = (lp == 1.0) ? lp * _Color : col;
			}		   
            ENDCG
        }
    }
}
