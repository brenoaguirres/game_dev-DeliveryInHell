Shader "PSXSub/PSX-Pixelation"
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

			#include "HLSLSupport.cginc"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

			sampler2D _MainTex;
			float _PixelationFactor;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
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

			half4 frag(v2f i, UNITY_VPOS_TYPE screenPos : VPOS) : SV_TARGET
			{
				float2 screenResolution = _ScreenParams.xy;
				float2 pixelSize = _ScreenParams.zw - 1;
				float2 pixelScalingFactor = screenResolution * _PixelationFactor;

				float2 pixelOrigin = floor((i.uv) * pixelScalingFactor) / pixelScalingFactor;

				half4 col = tex2D(_MainTex, pixelOrigin, float2(0, 0), float2(0, 0));

				return col;
			}
			ENDHLSL
		}
	}
}