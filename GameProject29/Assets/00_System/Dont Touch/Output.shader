Shader "Custom/Output" {

    Properties  {

        _MainTex ("Texture"	, 2D)				= "white" {}

		[Toggle]
		_CA		 ("Chromatic Aberration", int)			= 0
		_CALv	 ("CA Level"		, Range(0.0, 1.0))	= 0.0

		[Toggle]
		_Fill	 ("Fill"			, int)				= 0
		_FiCol	 ("Fill Color"		, Color)			= (1,1,1,1)
		_FiLv	 ("Fill Level"		, Range(0.0, 1.0))	= 0.0

		[Toggle]
		_Thick	 ("Line Thick"		, Range(0.5, 5.0))	= 1.0
		_Color	 ("Line Color"		, Color)			= (1,1,1,1)
		_DFLAG	 ("Use Depth"		, int)				= 0
		_CDIFF	 ("Color Differece"	, Range(0.0, 1.0))	= 0.00
		_NDIFF	 ("Normal Differece", Range(0.0, 1.0))	= 0.00
		_DDIFF	 ("Depth Differece"	, Range(0.0, 1.0))	= 0.00

		[Toggle]
		_Vigg	 ("Viggnet"			, int)				= 0
		_ViCol	 ("Viggnet Color"	, Color)			= (0,0,0,0)
		_ViLv	 ("Viggnet Level"	, Range(0.0, 1.0))	= 0.0
		_ViRg	 ("Viggnet Range"	, Range(0.0, 1.0))	= 0.0
    }

    SubShader {

        Cull	Off
		ZWrite	Off
		ZTest	Always

        Pass {
            CGPROGRAM
            #pragma vertex	 vert
            #pragma fragment frag

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

			int		_Vigg;
			fixed	_ViLv;
			fixed	_ViRg;
			fixed4	_ViCol;

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
			fixed4 Viggnet				(float2 uv, fixed4 col) {

				float2 vig;
				vig.x = uv.x * 2.0 - 1.0;
				vig.y = (1.0 - uv.y) * 2.0 - 1.0;

				float ret = pow(1.0 - dot(vig, vig) * _ViRg, _ViLv * 100.0);

				return lerp(_ViCol, col, ret);
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
				col = (_Vigg) ? Viggnet(i.uv, col) : col;
				
				return col;
			}
			
            ENDCG
        }
    }
}
