﻿Shader "PHNK/RayGun" {
        
        Properties 
        {
            _MainTex ("Texture", 2D) = "white" {}
            _HiddenTex ("Hidden texture", 2D) = "white" {}
			_DClipOff ("Dot Product clipoff", Range(0, 1)) = 0.4
			_MinDistance ("Minimum distance", Range(0, 5)) = 2
			_MaxDistance ("Maximum distance", Range(0, 50)) = 5
            _RayPosition ("Ray Position", Vector) = (0, 0, 0, 0)
            _RayDirection ("Ray Direction", Vector) = (0, 0, 0, 0)
            _SmoothFalloff ("Smoothing", Range(0, 1)) = 0.2
        }
        
        SubShader 
        {
            Tags {  "RenderType" = "Opaque" }
            CGPROGRAM
            #pragma surface surf Standard
            struct Input {
                float2 uv_MainTex;
                float2 uv_HiddenTex;
                float3 worldPos;
            };
            
            sampler2D _MainTex;
            sampler2D _HiddenTex;
			float _InputFlashlight;
			float _DClipOff;
			float _MinDistance;  
			float _MaxDistance;
			float _SmoothFalloff;
            float3 _RayPosition;
            float3 _RayDirection;
            
            float easein(float start, float end, float value)
            {
                end -= start;
                return end * value * value * value * value + start;
            }
            
            void surf (Input IN, inout SurfaceOutputStandard o) {
                fixed4 mainColour = tex2D (_MainTex, IN.uv_MainTex);
                fixed4 hiddenColour = tex2D (_HiddenTex, IN.uv_HiddenTex);
                
                float3 rayGunDir = _RayPosition.xyz - IN.worldPos;
                float distance = length(rayGunDir);
                rayGunDir = normalize(rayGunDir);
                float d = dot(rayGunDir, _RayDirection) * -1;
                float dot = d;
                float distMultiplier = max(distance - _MinDistance, 0) / (_MaxDistance - _MinDistance);
                d -= distMultiplier;
                
                //d *= max(sign(d - _DClipOff), 0);
                //d = 0;
                //if(dot < _DClipOff + (1-_DClipOff)*_SmoothFalloff && dot > _DClipOff) {
                    d = 1-((1-dot)/(1-_DClipOff));//*_SmoothFalloff));
                //}
                d = easein(0, 1, max(d, 0));
                o.Albedo = lerp(mainColour, hiddenColour, d * _InputFlashlight);
                
            }
            ENDCG
        }
        Fallback "Diffuse"
    }