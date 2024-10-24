Shader "PSXSub/PSX-Dithering"
{
    // May need to change file name to .cginc extension
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
            LOD 100

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "HLSLSupport.cginc"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float3 _ColorResolution;
            float3 _DitherResolution;
            sampler2D _MainTex;
            float _HighResDitherMatrix;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float uv : TEXCOORD0;

            };

            v2f vert(
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

            float DitherColorChannel(float color, float ditherThreshold, float ditherStep)
            {
                float distance = fmod(color, ditherStep);
                float baseValue = floor(color / ditherStep) * ditherStep;

                return lerp(baseValue, baseValue + ditherStep, step(ditherThreshold, distance / ditherStep - 0.001f));
            }
            
            float GetDitherThreshold(float2 pixelPosition)
            {
                const int ditheringMatrix4x4[16] =
                {
                    0,  8,  2,  10,
					12, 4,  14, 6,
					3,  11, 1,  9,
					15, 7,  13, 5
                };

                const int ditheringMatrix2x2[4] =
				{
					0, 3,
					2, 1
				};

                return lerp(
					ditheringMatrix2x2[fmod(pixelPosition.x, 2) + fmod(pixelPosition.y, 2) * 2] * 0.25f
					, ditheringMatrix4x4[fmod(pixelPosition.x, 4) + fmod(pixelPosition.y, 4) * 4] * 0.0625f
					, _HighResDitherMatrix);
            }

            half4 frag(v2f i, UNITY_VPOS_TYPE screenPos : VPOS) : SV_Target
			{
				const int2 pixelPosition = screenPos.xy;
				const float ditherThreshold = GetDitherThreshold(pixelPosition);
				const float3 ditherStep = 1.0f / max(_DitherResolution, 1.0f);
				const float3 colorStep = 1.0f / max(_ColorResolution, 1.0f);

				half4 col = tex2D(_MainTex, i.uv);
				col.r = DitherColorChannel(col.r, 0.5f, colorStep.r);
				col.g = DitherColorChannel(col.g, 0.5f, colorStep.g);
				col.b = DitherColorChannel(col.b, 0.5f, colorStep.b);

				col.r = DitherColorChannel(col.r, ditherThreshold, ditherStep.r);
				col.g = DitherColorChannel(col.g, ditherThreshold, ditherStep.g);
				col.b = DitherColorChannel(col.b, ditherThreshold, ditherStep.b);

				return col;
			}
            ENDHLSL
        }
    }
    FallBack "Diffuse"
}
