using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RayGun : MonoBehaviour
{
    [SerializeField] private Material _targetMaterial;

    public Material TargetMaterial
    {
        get { return _targetMaterial; }
        set { _targetMaterial = value; }
    }

    void Update()
    {
        if (!TargetMaterial)
        {
            return;
        }

        TargetMaterial.SetVector("_RayPosition", transform.position);
        TargetMaterial.SetVector("_RayDirection", transform.forward);
    }
}