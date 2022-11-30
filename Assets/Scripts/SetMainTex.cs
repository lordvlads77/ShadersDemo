using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMainTex : MonoBehaviour
{
    public Texture2D _SampleTexture;
    public Texture2D _noTex = null;
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetTexture("_MainTex", _SampleTexture);
    }

    private void Update()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetTexture("_MainTex", _noTex);
    }
}
