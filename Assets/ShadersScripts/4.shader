Shader "Custom/4"
{
	Properties{
		 _Color("Color", Color) = (1,1,1,1)
		 _MainTex("Albedo (RGB)", 2D) = "white" {}
		 _Glossiness("Smoothness", Range(0,1)) = 0.5
		 _Metallic("Metallic", Range(0,1)) = 0.0

		 _ControlTime("Time", float) = 0
		 _ModelOrigin("Model Origin", Vector) = (0,0,0,0)
		 _ImpactOrigin("Impact Origin", Vector) = (-5,0,0,0)

		 _Frequency("Frequency", Range(0, 1000)) = 10
		 _Amplitude("Amplitude", Range(0, 5)) = 0.1
		 _WaveFalloff("Wave Falloff", Range(1, 8)) = 4
		 _MaxWaveDistortion("Max Wave Distortion", Range(0.1, 2.0)) = 1
		 _ImpactSpeed("Impact Speed", Range(0, 10)) = 0.5
		 _WaveSpeed("Wave Speed", Range(-10, 10)) = -5
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			 // Modelo de iluminación :D
			 #pragma surface surf Standard fullforwardshadows addshadow vertex:vert

			 #pragma target 3.0

			 sampler2D _MainTex;

			 struct Input {
				 float2 uv_MainTex;
			 };

			 half _Glossiness;
			 half _Metallic;
			 fixed4 _Color;

			 float _ControlTime;
			 float4 _ModelOrigin;
			 float4 _ImpactOrigin;

			 half _Frequency; //Frecuencia base para nuestras ondas.
			 half _Amplitude; //Amplitud base para nuestras ondas.
			 half _WaveFalloff; //Qué tan rápido debería caer nuestra distorsión dada la distancia.
			 half _MaxWaveDistortion; //Un número más pequeño aquí conducirá a una mayor distorsión a medida que el vértice se acerque al origen.
			 half _ImpactSpeed; //Qué tan rápido se mueve el origen de nuestra onda a través de la esfera.
			 half _WaveSpeed; //Velocidad de oscilación de una onda individual.

			 void vert(inout appdata_base v) {
				 float4 world_space_vertex = mul(unity_ObjectToWorld, v.vertex);

				 float4 direction = normalize(_ModelOrigin - _ImpactOrigin);
				 float4 origin = _ImpactOrigin + _ControlTime * _ImpactSpeed * direction;

				
				 float dist = distance(world_space_vertex, origin);

			
				 dist = pow(dist, _WaveFalloff);

				 dist = max(dist, _MaxWaveDistortion);

				
				 float4 l_ImpactOrigin = mul(unity_WorldToObject, _ImpactOrigin);
				 float4 l_direction = mul(unity_WorldToObject, direction);

				
				 float impactAxis = l_ImpactOrigin + dot((v.vertex - l_ImpactOrigin), l_direction);

				 v.vertex.xyz += v.normal * sin(impactAxis * _Frequency + _ControlTime * _WaveSpeed) * _Amplitude * (1 / dist);
			 }

			 void surf(Input IN, inout SurfaceOutputStandard o) {
				 fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				 o.Albedo = c.rgb;
				 o.Metallic = _Metallic;
				 o.Smoothness = _Glossiness;
				 o.Alpha = c.a;
			 }
			 ENDCG
		 }
			 FallBack "Diffuse"
}
