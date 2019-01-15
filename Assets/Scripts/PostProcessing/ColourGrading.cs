using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[ExecuteInEditMode]
public class ColourGrading : MonoBehaviour {
	private RotateAround rot;
    [Range(0.01f, 1)] public float _rIntensity = 1;
    [Range(0.01f, 1)] public float _gIntensity = 1;
    [Range(0.01f, 1)] public float _bIntensity = 1;
    [Range(0, 1)] public float _colorGradient = 0f;



    [SerializeField] private Material _material;


    private void Start() {
	    rot = GameObject.Find("Area Light").GetComponent<RotateAround>();
    }

	void Update() {
		_colorGradient = rot.range;
	}

    void OnRenderImage(RenderTexture source, RenderTexture destination){
        if (_material == null){
            return;
        }

        _material.SetFloat("_RIntensity", _rIntensity);
        _material.SetFloat("_GIntensity", _gIntensity);
        _material.SetFloat("_BIntensity", _bIntensity);
        _material.SetFloat("_GradientPos", _colorGradient);

        Graphics.Blit(source, destination, _material);
    }
}
