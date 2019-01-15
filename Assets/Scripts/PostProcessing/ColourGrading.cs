using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColourGrading : MonoBehaviour {
    [Range(0.01f, 1)] public float _intensity;

    private Material _material;


    private void Awake(){
        _material = new Material(Shader.Find("PHNK/DayNight"));
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination){
        if (_material == null){
            return;
        }

        if (_intensity == 0){
            Graphics.Blit(source, destination, _material);
            return;
        }

        _material.SetFloat("_Intensity", _intensity);
        Graphics.Blit(source, destination, _material);
    }
}
