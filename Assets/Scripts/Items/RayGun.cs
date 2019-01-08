using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RayGun : MonoBehaviour
{
    [SerializeField] private Material[] _targetMaterial;
    
    private static readonly int RayPosition = Shader.PropertyToID("_RayPosition");
    private static readonly int RayDirection = Shader.PropertyToID("_RayDirection");

    [SerializeField] bool isOn = false;

    void Update()
    {
        if (_targetMaterial.Length == 0)
        {
            return;
        }
        
            foreach (var t in _targetMaterial)
            {
                t.SetVector(RayPosition, transform.position);
                t.SetVector(RayDirection, transform.forward);
            t.SetFloat("_InputFlashlight", isOn ? 1 : 0);
            }
        
    }
}