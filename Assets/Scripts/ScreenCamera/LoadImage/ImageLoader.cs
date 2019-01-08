using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    private ImagesCounter _counter;
    private ArrayList _imageBuffer;
    private string _path;
    private string _filename;
    private string _fileType;

    void Start()
    {
        _counter = FindObjectOfType<ImagesCounter>();
        _imageBuffer = new ArrayList();
        _path = Application.dataPath + "/ScreenShots/";
        _filename = "snap_";
        _fileType = ".png";
        StartCoroutine(LoadImages());
    }

    private IEnumerator LoadImages()
    {
        for (int i = 0; i < _counter.Counter; i++)
        {
            string fullFilename = _path + _filename + i + _fileType;
            WWW www = new WWW(fullFilename);
            yield return www;
            Texture2D texTmp = new Texture2D(1024, 1024, TextureFormat.DXT5, false);
            //LoadImageIntoTexture compresses JPGs by DXT1 and PNGs by DXT5     
            www.LoadImageIntoTexture(texTmp);
            _imageBuffer.Add(texTmp);

        }
    }
}
