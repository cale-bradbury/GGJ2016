Shader "Elevator/Post" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {
	Pass {
		ZTest Always Cull Off ZWrite Off
		Fog { Mode off }
		Stencil{
			Ref 2
			ReadMask 2
			Comp NotEqual
		}
CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest 
#pragma target 3.0
#include "UnityCG.cginc"

uniform sampler2D _MainTex;	//the screen texture

float4 frag (v2f_img i) : COLOR{
	float2 uv = i.uv;
	#if UNITY_UV_STARTS_AT_TOP
		//uv.y = 1.0-uv.y;
	#endif
	return tex2D(_MainTex,uv);
}
ENDCG

	}
}

Fallback off

}