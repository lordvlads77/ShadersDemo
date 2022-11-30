using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchShaders : MonoBehaviour
{
    [SerializeField] private Material[] _mats;
    [SerializeField] private MeshRenderer _mesh;
    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        StartCoroutine(MaterialChange());
    }

    private IEnumerator MaterialChange()
    {
        while (true)
        {
            for (int i = 0; i < _mats.Length; i++)
            {
                _mesh.material = _mats[i];
                yield return new WaitForSeconds(10f);
            }
        }
    }
} 
