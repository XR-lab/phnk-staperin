Shader "PHNK/RayGun" {
        
        Properties 
        {
            _MainTex ("Texture", 2D) = "white" {}
            _RayTex ("Texture", 2D) = "white" {}
			_DClipOff ("Dot Product clipoff", Range(0, 1)) = 0.4
			_MinDistance ("Dot Product clipoff", Range(0, 5)) = 2
			_MaxDistance ("Dot Product clipoff", Range(0, 50)) = 5
            _RayPosition ("Ray Position", Vector) = (0, 0, 0, 0)
            _RayDirection ("Ray Position", Vector) = (0, 0, 0, 0)
        }
        
        SubShader 
        {
            Tags { "RenderType" = "Opaque" }
            
            CGPROGRAM
            #pragma surface surf Standard
                        
            struct Input {
                float2 uv_MainTex;
                float2 uv_RayTex;
                float3 worldPos;
            };
            
            sampler2D _MainTex;
            sampler2D _RayTex;
			float _DClipOff;
			float _MinDistance;
			float _MaxDistance;
            float3 _RayPosition;
            float3 _RayDirection;
            
            void surf (Input IN, inout SurfaceOutputStandard o) {
                fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
                fixed4 c2 = tex2D (_RayTex, IN.uv_RayTex);
                
                float3 rayGunDir = _RayPosition.xyz - IN.worldPos;
                float distance = length(rayGunDir);
                rayGunDir = normalize(rayGunDir);
                float d = dot(rayGunDir, _RayDirection) * -1;
                float distMultiplier = max(distance - _MinDistance, 0) / (_MaxDistance - _MinDistance);
                d -= distMultiplier;
                
                d *= max(sign(d - _DClipOff), 0);
                
                o.Albedo = lerp(c, c2, d);
                
            }
            ENDCG
        }
        Fallback "Diffuse"
    }