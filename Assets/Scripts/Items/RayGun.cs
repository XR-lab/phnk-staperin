using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RayGun : MonoBehaviour
{
    [SerializeField] private Material _targetMaterial;

    public Material TargetMaterial => _targetMaterial;

    void Update()
    {
        if (!TargetMaterial)
        {
            return;
        }

        TargetMaterial.SetVector("_RayPosition", transform.position);
        TargetMaterial.SetVector("_RayDirection", transform.forward);
    }

    void OnDisable()
    {
        TargetMaterial.SetFloat("_HiddenLayerEnabled", 0f);
    }

    void OnEnable()
    {
        TargetMaterial.SetFloat("_HiddenLayerEnabled", 1f);
    }

    
}