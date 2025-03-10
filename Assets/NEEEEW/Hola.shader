Shader "Custom/Hola"
{
    Properties
    {
        _Color ("", Color) = (1,1,1,1)
        _MainTex ("", 2D) = "white" {}
     
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        sampler2D _MainTex;
        struct Input
        {
            float2 uv_MainTex;
        };
        fixed4 _Color;
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
        }
        ENDCG
    }
    
}
