using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim6 : MonoBehaviour
{
	//me activa la animación c:
	public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
	public string textureName = "_MainTex";

	Vector2 uvOffset = Vector2.zero;

	void LateUpdate()
	{
		uvOffset += (uvAnimationRate * Time.deltaTime);
		if (GetComponent<Renderer>().enabled)
		{
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset(textureName, uvOffset);
		}
	}
}
