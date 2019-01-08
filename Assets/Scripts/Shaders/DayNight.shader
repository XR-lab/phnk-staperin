Shader "PHNK/DayNight" {
	
    Properties {
	    _MainTex ("Base (RGB)", 2D) = "white" {}
        _Intensity ("Color intensity", Float) = "white" {}
        
	}
    
	SubShader {
    
		Pass {
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            uniform sampler2D _MainTex;
            
            float _Intensity;
            
            float4 frag(v2f_img i) : COLOR {
                float4 c = tex2D(_MainTex, i.uv);
                
                float3  = c.rgb * _Intensity;
                
                float4 result = c;
                result.rgb = lerp(c.rgb, bw, _bwBlend);
                return result;
            }
            ENDCG
		}
	} 
}
