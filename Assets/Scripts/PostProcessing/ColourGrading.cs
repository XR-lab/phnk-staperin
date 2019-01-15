﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColourGrading : MonoBehaviour {
    [Range(0.01f, 1)] public float _rIntensity;
    [Range(0.01f, 1)] public float _gIntensity;
    [Range(0.01f, 1)] public float _bIntensity;


    [SerializeField] private Material _material;


    private void Awake(){

    }

    void OnRenderImage(RenderTexture source, RenderTexture destination){
        if (_material == null){
            return;
        }


        _material.SetFloat("_RIntensity", _rIntensity);
        _material.SetFloat("_GIntensity", _gIntensity);
        _material.SetFloat("_BIntensity", _bIntensity);
        Graphics.Blit(source, destination, _material);
    }
}
