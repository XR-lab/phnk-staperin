using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamMaterial : MonoBehaviour
{
    [SerializeField] private int width = 1280;
    [SerializeField] private int height = 720;
    [SerializeField] private int fps = 30;

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    public int FPS
    {
        get { return fps; }
        set { fps = value; }
    }

    void Start()
    {
        var webcamTexture = new WebCamTexture(WebCamTexture.devices[0].name, Width, Height, FPS);
        var renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        var aspectRatio = Width / (float) Height;
        transform.localScale = new Vector3(transform.localScale.x * aspectRatio, transform.localScale.y,
            transform.localScale.z);
        webcamTexture.Play();
    }
}