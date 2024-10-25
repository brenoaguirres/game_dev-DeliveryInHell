﻿Shader "PSX/Lite/Vertex Lit Transparent"
{
	Properties
	{
		_Color("Color (RGBA)", Color) = (1, 1, 1, 1)
		_EmissionColor("Emissive Color(RGBA)", Color) = (0,0,0,0)
		_MainTex("Texture", 2D) = "white" {}
		_EmissiveTex("Emissive", 2D) = "black" {}
		_ObjectDithering("Per-Object Dithering Enable", Range(0,1)) = 1
	}

	SubShader
	{
		Tags {"RenderType" = "Transparent" "Queue" = "Transparent"}
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100

		Pass
		{
			Tags { "LightMode" = "VertexLM" }
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
            #pragma multi_compile __ PSX_ENABLE_CUSTOM_VERTEX_LIGHTING

			#define PSX_TRIANGLE_SORT_OFF
			#include "UnityCG.cginc"
            #include "HLSLSupport.cginc"

			#include "PSX-Utils.hlsl"

			#define PSX_VERTEX_LIT
			#include "PSX-ShaderSrc-Lite.hlsl"

			ENDHLSL
		}

		Pass
		{
			Tags { "LightMode" = "Vertex" }
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
            #pragma multi_compile __ PSX_ENABLE_CUSTOM_VERTEX_LIGHTING

			#include "UnityCG.cginc"
            #include "HLSLSupport.cginc"

			#include "PSX-Utils.hlsl"

			#define PSX_VERTEX_LIT
			#include "PSX-ShaderSrc-Lite.hlsl"

			ENDHLSL
		}
	}
	
	Fallback "PSX/Lite/Unlit Transparent"
}