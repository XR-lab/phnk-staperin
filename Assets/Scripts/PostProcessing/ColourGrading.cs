using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[ExecuteInEditMode]
public class ColourGrading : MonoBehaviour {
	public float Range { get; set; }
    [Range(0, 1)] public float _colorGradient = 0f;



    [SerializeField] private Material _material;

	void Update() {
		_colorGradient = Range;
	}

    void OnRenderImage(RenderTexture source, RenderTexture destination){
        if (_material == null){
            return;
        }

	    _material.SetFloat("_GradientPos", _colorGradient);

        Graphics.Blit(source, destination, _material);
    }
}
