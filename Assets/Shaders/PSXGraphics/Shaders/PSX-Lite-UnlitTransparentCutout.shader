Shader "PSX/Lite/Unlit Cutout"
{
    Properties
    {
        _Color("Color (RGBA)", Color) = (1, 1, 1, 1)
        _MainTex("Texture", 2D) = "white" {}
        _Cutoff("Alpha cutoff", Range(0,1)) = 0.1
        _ObjectDithering("Per-Object Dithering Enable", Range(0,1)) = 1
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
            #pragma fragment frag
            #pragma multi_compile_fog

            #define PSX_TRIANGLE_SORT_OFF
            #include "UnityCG.cginc"
            #include "HLSLSupport.cginc"

            #include "PSX-Utils.hlsl"

            #define PSX_CUTOUT_VAL _Cutoff
            float _Cutoff;
            #include "PSX-ShaderSrc-Lite.hlsl"

            ENDHLSL
        }
    }
    
    Fallback "Unlit/Color"
}