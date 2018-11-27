// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "PHNK/ImageDisplacement"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_PaintTex("Texture paint", 2D) = "white" {}
		_DisplaceTex("Displacement Texture", 2D) = "white" {}
		_Magnitude("Magnitude", Range(0,0.01)) = 1
		
		_CrackTex ("Cracks", 2D) = "white" {}
        _CrackColor ("Cracks Color", Color) = (0.5, 0.5, 0.5, 1)
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};
			
			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				half3 worldNormal : TEXCOORD1;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _DisplaceTex;
			sampler2D _PaintTex;
			float _Magnitude;
			
			sampler2D _CrackTex;
            float3 _CrackColor;
            half _Cutoff;

			float4 frag (v2f i) : SV_Target
			{
				float2 distuv = i.uv;

				float2 disp = tex2D(_DisplaceTex, distuv * 40).xy;
				float3 paint = 1 + tex2D(_PaintTex, distuv * 7);
				disp = ((disp * 2) - 1) * _Magnitude;
				
				fixed4 crackTex = tex2D(_CrackTex, distuv * 2 );
                float crackVisibility = saturate((crackTex.a - _Cutoff ) * 10);

				float4 col = tex2D(_MainTex, i.uv + disp);
				col.rgb *= paint;
				
				
                col.rgb = lerp(col.rgb, crackTex.rgb * _CrackColor, crackVisibility);
                
                
				return col;
			}
			ENDCG
		}
	}
}