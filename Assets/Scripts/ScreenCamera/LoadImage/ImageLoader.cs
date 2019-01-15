using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    private ImagesCounter _counter;
    private List<Texture2D> _imageBuffer;
    private string _path;
    private string _filename;
    private string _fileType;

    void Awake()
    {
        _counter = FindObjectOfType<ImagesCounter>();
        _imageBuffer = new List<Texture2D>();
        _path = Application.dataPath + "/ScreenShots/";
        _filename = "snap_";
        _fileType = ".png";
    }

    public List<Texture2D> LoadImages()
    {
        _counter.LoadCounter();
        for (int i = 0; i < _counter.Counter; i++)
        {
            string fullFilename = _path + _filename + i + _fileType;
            WWW www = new WWW(fullFilename);
            Texture2D texTmp = new Texture2D(1024, 1024, TextureFormat.DXT5, false);
            www.LoadImageIntoTexture(texTmp);
            _imageBuffer.Add(texTmp);
        }
        return _imageBuffer;
    }
}
