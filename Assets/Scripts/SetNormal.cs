using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNormal : MonoBehaviour
{
    public Texture2D _NormalMapTexture;

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetTexture("_BumpMap", _NormalMapTexture);
    }

    /*private void Update()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.
    }*/
}
