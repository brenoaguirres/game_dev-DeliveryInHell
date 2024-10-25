Shader "Hidden/PSX-Interlacing"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Pass
        {
            Cull Off ZWrite Off ZTest Always
            Tags
            {
                "RenderPipeline"="UniversalRenderPipeline"
            }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "HLSLSupport.cginc"

            sampler2D _MainTex;
            sampler2D _PreviousFrame;
            half _InterlacedFrameIndex;
            half _InterlacingSize;

            struct appdata
            {
                float4 vertex : POSITION;
                float4 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
            };

            v2f vert
            (
                float4 vertex : POSITION, 
                float2 uv : TEXCOORD0, 
                out float4 outpos : SV_POSITION
            )
            {
                v2f o;
                o.uv = uv;
                outpos = TransformObjectToHClip(vertex);
                return o;
            }

            half4 frag(v2f i, UNITY_VPOS_TYPE screenPos : VPOS) : SV_Target
            {
                half4 col = tex2D(_MainTex, i.uv);
                half4 previousColor = tex2D(_PreviousFrame, i.uv);

                const int2 pixelPosition = screenPos.xy;
                half interlacingAreaCheck = floor(pixelPosition.y / _InterlacingSize) % 2 == round(_InterlacedFrameIndex);
                return lerp(col, previousColor, interlacingAreaCheck);
            }
            ENDHLSL
        }
    }
}
