// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Hidden/Custom-DeferredShading" {
Properties {
    _LightTexture0 ("", any) = "" {}
    _LightTextureB0 ("", 2D) = "" {}
    _ShadowMapTexture ("", any) = "" {}
    _SrcBlend ("", Float) = 1
    _DstBlend ("", Float) = 1
}
SubShader {

	Pass {
	    ZWrite Off
	    Blend [_SrcBlend] [_DstBlend]
	
	CGPROGRAM
	#pragma target 3.0
	#pragma vertex vert_deferred
	#pragma fragment frag
	
	#pragma exclude_renderers nomrt
	
	#include "UnityCG.cginc"
	#include "UnityDeferredLibrary.cginc"
	
		sampler2D _CameraGBufferTexture0;
	
		half4 CalculateLight (unity_v2f_deferred i)
		{
		    float2 uv = i.uv.xy / i.uv.w;
		    return half4(tex2D(_CameraGBufferTexture0, uv).rgb, 1.0);
		}
	
		fixed4 frag (unity_v2f_deferred i) : SV_Target {

		    half4 c = CalculateLight(i);
		    return exp2(-c);
		}
	
	ENDCG
	}

	Pass {

    ZTest Always Cull Off ZWrite Off

    Stencil {
        ref		 [_StencilNonBackground]
        readmask [_StencilNonBackground]
        compback equal
        compfront equal
    }

	CGPROGRAM
	#pragma target   3.0
	#pragma vertex   vert
	#pragma fragment frag
	#pragma exclude_renderers nomrt
	
	#include "UnityCG.cginc"
	
	sampler2D _LightBuffer;

	struct v2f {
	    float4 vertex : SV_POSITION;
	    float2 texcoord : TEXCOORD0;
	};

	v2f vert (float4 vertex : POSITION, float2 texcoord : TEXCOORD0)
	{
	    v2f o;
	    o.vertex	= UnityObjectToClipPos(vertex);
	    o.texcoord	= texcoord.xy;
	
	    return o;
	}

	fixed4 frag (v2f i) : SV_Target
	{
	    return -log2(tex2D(_LightBuffer, i.texcoord));
	}

	ENDCG
	}

	}
	Fallback Off
}
