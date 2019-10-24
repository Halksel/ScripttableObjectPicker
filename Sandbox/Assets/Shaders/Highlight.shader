Shader "Custom/Highlight"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_AlphaCutOut("AlphaCutOut", Range(0,1)) = 1
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass
			{
				Stencil
				{
					Ref 1
					Comp Always
					Pass Replace
				}
				ColorMask 0
				Zwrite Off
				CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag

				#include "UnityCG.cginc"

				sampler2D _MainTex;
				float	  _AlphaCutOut;

				fixed4 frag(v2f_img i) : COLOR
				{
					fixed4 col = tex2D(_MainTex, i.uv);
					clip(col.r - _AlphaCutOut);
					return 1;
				}
				ENDCG
			}
		}
			FallBack "Diffuse"
}
