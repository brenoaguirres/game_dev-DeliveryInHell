Shader "PSX/Unlit Transparent"
{
    Properties
    {
        _Color("Color (RGBA)", Color) = (1, 1, 1, 1)
        _MainTex("Texture", 2D) = "white" {}
        _CustomDepthOffset("Custom Depth Offset", Float) = 0
    }

    SubShader
    {
        Tags {"RenderType" = "Transparent" "Queue" = "Transparent"}
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma geometry geom
            #pragma fragment frag
            #pragma multi_compile_fog
            #pragma multi_compile __ PSX_ENABLE_TRIANGLE_SORTING
            #pragma multi_compile __ PSX_ENABLE_CUSTOM_VERTEX_LIGHTING

            #include "UnityCG.cginc"
            #include "HLSLSupport.cginc"
            #include "PSX-Utils.hlsl"

            #include "PSX-ShaderSrc.hlsl"

            ENDHLSL
        }
    }
        Fallback "Unlit/Color"
}