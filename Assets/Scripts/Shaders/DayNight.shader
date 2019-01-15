Shader "PHNK/DayNight" {
    
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _GradientTex ("Lighting Color Gradient", 2D) = "white"{}
        _GradientPos ("Position In Gradient", Range(0,1)) = 0.5
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
            uniform sampler2D _GradientTex;
            
            float _RIntensity;
            float _GIntensity;
            float _BIntensity;
            
            float _GradientPos;

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
                float2 uv = float2(_GradientPos,0);
                float4 c = tex2D(_MainTex, i.uv);
                float4 g = tex2D(_GradientTex, uv);
                
                c.r *= _RIntensity;
                c.g *= _GIntensity;
                c.b *= _BIntensity;
                
                float4 result = c * g;
                return result;
            }
            
            ENDCG
        }
    } 
}
