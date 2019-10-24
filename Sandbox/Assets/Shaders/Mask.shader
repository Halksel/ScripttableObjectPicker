Shader "Custom/Mask"
{
	Properties
	{
	}
	SubShader
	{
		Tags {	
				"Queue" = "Transparent" 
				"IgnoreProjector"="True"
				"RenderType" = "Transparent"
			 }
		LOD 100

		Pass
		{
			Stencil
			{
				Ref 0
				Comp Equal
			}
			Zwrite Off
			Blend SrcAlpha OneMinusSrcAlpha 
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"

			fixed4 frag(v2f_img i) : Color 
			{
				fixed4 col = fixed4(0,0,0,0.5);
				return col;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
