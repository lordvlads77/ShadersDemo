using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private MeshRenderer _meshRenderer;
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(ChangeMaterials());
    }

    private IEnumerator ChangeMaterials()
    {
        while (true)
        {
            for (int i = 0; i < _materials.Length; i++)
            {
                _meshRenderer.material = _materials[i];
                yield return new WaitForSeconds(10f);
            }
        }
    }
}
