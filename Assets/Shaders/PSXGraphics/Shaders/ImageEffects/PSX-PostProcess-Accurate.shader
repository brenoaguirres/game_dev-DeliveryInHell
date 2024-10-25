Shader "Hidden/PSX-PostProcess-Accurate"
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
				"RenderPipeline" = "UniversalRenderPipeline"
			}

			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "HLSLSupport.cginc"

			sampler2D _MainTex;
			float _DitheringScale;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float2 uv : TEXCOORD0;
			};

			v2f vert(
				float4 vertex : POSITION, // vertex position input
				float2 uv : TEXCOORD0, // texture coordinate input
				out float4 outpos : SV_POSITION // clip space position output
			)
			{
				v2f o;
				o.uv = uv;
				outpos = TransformObjectToHClip(vertex);
				return o;
			}

			int PSX_GetDitherOffset(int2 pixelPosition)
			{
				const int ditheringMatrix4x4[16] =
				{
					-4, +0, -3, +1,
					+2, -2, +3, -1,
					-3, +1, -4, +0,
					+3, -1, +2, -2
				};

				return ditheringMatrix4x4[pixelPosition.x % 4 + (pixelPosition.y % 4) * 4];
			}

			half4 PSX_DitherColor(float4 color, int2 pixelPosition)
			{
				int4 col255 = round(color * 255) + PSX_GetDitherOffset(pixelPosition.xy);
				col255 = col255 >> 3;

				return col255 / 31.0f;
			}


			half4 frag(v2f i, UNITY_VPOS_TYPE screenPos : VPOS) : SV_Target
			{
				half4 col = tex2D(_MainTex, i.uv);
				return PSX_DitherColor(col, floor(screenPos.xy * _DitheringScale));
			}
			ENDHLSL
		}
	}
}