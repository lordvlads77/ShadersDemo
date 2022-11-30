Shader "Custom/6"
{
	Properties
	{
		_DistortX("Distortion in X", Range(0,2)) = 1
		_DistortY("Distortion in Y", Range(0,2)) = 0
		_MainTex("_MainTex RGBA", 2D) = "white" {}
		_Distort("_Distort A", 2D) = "white" {}
		_LavaTex("_LavaTex RGB", 2D) = "white" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 150

		CGPROGRAM
		#pragma surface surf Lambert noforwardadd
		//distorsiones para que tenga efecto de lava D:
		sampler2D _MainTex;
		sampler2D _Distort;
		sampler2D _LavaTex;
		fixed _DistortX;
		fixed _DistortY;

		struct Input
		{
			float2 uv2_LavaTex;
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			fixed distort = tex2D(_Distort, IN.uv_MainTex).a;

			fixed2 uv_scroll;
			uv_scroll = fixed2(IN.uv2_LavaTex.x - distort * _DistortX,IN.uv2_LavaTex.y - distort * _DistortY);

			fixed4 tex2 = tex2D(_LavaTex,uv_scroll);
			//hacemos una operación para el calculo de shader
			c.rgb = lerp(tex2.rgb,c.rgb,c.a);

			o.Albedo = c.rgb;
			o.Alpha = c.a;

		}
		ENDCG
	}

		Fallback "Mobile/VertexLit"
}
