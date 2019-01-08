Shader "PHNK/RayGunObjectShower" {
        
        Properties 
        {
            _MainTex ("Texture", 2D) = "white" {}
			_DClipOff ("Dot Product clipoff", Range(0, 1)) = 0.4
			_MinDistance ("Minimum distance", Range(0, 5)) = 2
			_MaxDistance ("Maximum distance", Range(0, 50)) = 5
            _RayPosition ("Ray Position", Vector) = (0, 0, 0, 0)
            _RayDirection ("Ray Direction", Vector) = (0, 0, 0, 0)
        }
        
        SubShader 
        {
            Tags {  "RenderType" = "Transparent" 
                    "Queue" = "Transparent"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

            CGPROGRAM
            #pragma surface surf Standard alpha:fade
                        
            struct Input {
                float2 uv_MainTex;
                float3 worldPos;
            };
            
            sampler2D _MainTex;
			float _InputFlashlight;
			float _DClipOff;
			float _MinDistance;
			float _MaxDistance;
            float3 _RayPosition;
            float3 _RayDirection;
            
            void surf (Input IN, inout SurfaceOutputStandard o) {
                fixed4 mainColour = tex2D (_MainTex, IN.uv_MainTex);
                
                float3 rayGunDir = _RayPosition.xyz - IN.worldPos;
                float distance = length(rayGunDir);
                rayGunDir = normalize(rayGunDir);
                float d = dot(rayGunDir, _RayDirection) * -1;
                float distMultiplier = max(distance - _MinDistance, 0) / (_MaxDistance - _MinDistance);
                d -= distMultiplier;
                
                d *= max(sign(d - _DClipOff), 0);
                
                o.Albedo = mainColour;
                o.Alpha = _InputFlashlight * lerp(0, 1, d);
            }
            ENDCG
        }
        Fallback "Diffuse"
    }