﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColourGrading : MonoBehaviour {
    [Range(0, 1)] public float ColorGradient = 0.5f;

    [SerializeField] private Material _material;


    private void Awake(){

    }

    void OnRenderImage(RenderTexture source, RenderTexture destination){
        if (_material == null){
            return;
        }
        _material.SetFloat("_SamplePos", ColorGradient);

        Debug.Log(ColorGradient);

        Graphics.Blit(source, destination, _material);
    }
}
