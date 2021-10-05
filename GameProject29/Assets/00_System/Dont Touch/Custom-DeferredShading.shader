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
	
		fixed4 frag (unity_v2f_deferred i) : SV_Target {

			return tex2D(_CameraGBufferTexture0, i.uv);
		}
	
		ENDCG
	}

	Pass {

		ZTest	Always
		Cull	Off
		ZWrite	Off

		CGPROGRAM
		#pragma target   3.0
		#pragma vertex	 vert_deferred
		#pragma fragment frag

		#pragma exclude_renderers nomrt
	
		#include "UnityCG.cginc"
		#include "UnityDeferredLibrary.cginc"
	
		sampler2D _CameraGBufferTexture0;

		fixed4 frag (unity_v2f_deferred i) : SV_Target {
			return tex2D(_CameraGBufferTexture0, i.uv.xy);
		}

		ENDCG
	}

	}
	Fallback Off
}
