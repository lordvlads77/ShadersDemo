using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Dissolve : MonoBehaviour
{
    private MeshRenderer _Renderer;

    public float _disolveSpeed = .5f;

    private void Start(){
        _Renderer = this.GetComponent<MeshRenderer>();
    }

    private float _deltaTime = 0.0f;
    private void Update(){
        Material[] material = _Renderer.materials;

        material[0].SetFloat("_Cutoff", Mathf.Sin(_deltaTime * _disolveSpeed));
        _deltaTime += Time.deltaTime;
        
        // Unity does not allow meshRenderer.materials[0]...
        _Renderer.materials = material;
    }
}
