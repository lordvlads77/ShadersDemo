Shader "Custom/13"
{
    Properties
  {
    _Color("Color", Color) = (1,1,1,1)
    _MetallicTex ("Metallic", 2D) = "white" {}
    _Metallic ("Metallic", Range(0.0, 1.0)) = 0.0
    _BumpMap ("Normal Tex", 2D) = "bump" {}
    _MainTex ("Albedo RGB", 2D) = "white" {} 
  }
    SubShader
    {
      Tags
      {
        "Queue" = "Geometry"
      }

      CGPROGRAM
      #pragma surface surf Standard //Añadir Specular para hacerlo StandarSpec

      sampler2D _MetallicTex;
      half _Metallic;
      fixed4 _Color;
      sampler2D _MainTex;
      sampler2D _BumpMap;

      struct Input
      {
        float2 uv_MetallicTex;
        float2 uv_MainTex;
        float2 uv_BumpMap;
      };

      void surf(Input IN, inout SurfaceOutputStandard o) //Añadir Specular para hacer StandardSpec)
      {
        fixed4 a = tex2D(_MainTex, IN.uv_MainTex);
        o.Albedo = a.rgb;
        o.Metallic = tex2D (_MetallicTex, IN.uv_MetallicTex);
        o.Smoothness = _Metallic;
        o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
      }
      ENDCG
    }
    FallBack "Diffuse"
}
