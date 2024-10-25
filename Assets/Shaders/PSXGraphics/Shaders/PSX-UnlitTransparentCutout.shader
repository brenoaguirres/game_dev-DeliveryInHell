﻿Shader "PSX/Unlit Cutout"
{
    Properties
    {
        _Color("Color (RGBA)", Color) = (1, 1, 1, 1)
        _MainTex("Texture", 2D) = "white" {}
        _Cutoff("Alpha cutoff", Range(0,1)) = 0.1
        _ObjectDithering("Per-Object Dithering Enable", Range(0,1)) = 1
        _CustomDepthOffset("Custom Depth Offset", Float) = 0
    }
        SubShader
    {
        Tags {"RenderType" = "Opaque" }
        ZWrite On
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma geometry geom
            #pragma fragment frag
            #pragma multi_compile_fog
            #pragma multi_compile PSX_TRIANGLE_SORT_OFF PSX_TRIANGLE_SORT_CENTER_Z PSX_TRIANGLE_SORT_CLOSEST_Z PSX_TRIANGLE_SORT_CENTER_VIEWDIST PSX_TRIANGLE_SORT_CLOSEST_VIEWDIST PSX_TRIANGLE_SORT_CUSTOM

            #include "UnityCG.cginc"
            #include "HLSLSupport.cginc"
            #include "PSX-Utils.hlsl"

            #define PSX_CUTOUT_VAL _Cutoff
            float _Cutoff;
            #include "PSX-ShaderSrc.hlsl"

            ENDHLSL
        }
    }
        Fallback "PSX/Lite/Unlit Cutout"
}