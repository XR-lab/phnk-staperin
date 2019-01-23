using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamMaterial : MonoBehaviour
{

    public int Width { get; set; } = 1280;
    public int Height { get; set; } = 720;
    public int FPS { get; set; } = 30;
    private WebCamTexture _webcamTexture;

    void Start()
    {
        SetupTexture();
        SetAspectRatio();
        Play();
    }

    void SetupTexture()
    {
        _webcamTexture = new WebCamTexture(WebCamTexture.devices[0].name, Width, Height, FPS);
        var renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = _webcamTexture;
    }

    void SetAspectRatio()
    {
        var aspectRatio = Width / (float) Height;
        transform.localScale = new Vector3(transform.localScale.x * aspectRatio, transform.localScale.y,
            transform.localScale.z);
    }

    void Play()
    {
        _webcamTexture.Play();
    }
}