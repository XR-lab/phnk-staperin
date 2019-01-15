Shader "PHNK/DayNight" {
    
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _ClolorGradient ("Lighting Color Gradient", 2D) = "white"{}
        _RIntensity ("Red Color Intensity", Range(0.1, 1.0)) = 1.0
        _GIntensity ("Green Color Intensity", Range(0.1, 1.0)) = 1.0
        _BIntensity ("Blue Color Intensity", Range(0.1, 1.0)) = 1.0
    }
    
    SubShader {
    
        Pass {
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            uniform sampler2D _MainTex;
            
            float _RIntensity;
            float _GIntensity;
            float _BIntensity;

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
            
            float4 frag(v2f i) : COLOR {
                float4 c = tex2D(_MainTex, i.uv);
                
                c.r *= _RIntensity;
                c.g *= _GIntensity;
                c.b *= _BIntensity;
                
                float4 result = c;
                return result;
            }
            
            ENDCG
        }
    } 
}
