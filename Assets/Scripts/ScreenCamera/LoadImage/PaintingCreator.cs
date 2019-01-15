using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject _paintingPref;
    [SerializeField]
    private List<Transform> _positions;
    private ImageLoader _imgLoader;

    // Start is called before the first frame update
    void Start()
    {
        _imgLoader = GetComponent<ImageLoader>();
        CreatePaintings();
    }

    private void CreatePaintings()
    {
        List<Texture2D> images = _imgLoader.LoadImages();
        for (int i = 0; i < images.Count; i++)
        {
            GameObject temp = Instantiate(_paintingPref);
            int tempX = i / 2;
            int tempY = i % 2;
            if (tempY == 1)
            {
                tempY *= -1;
            }
            temp.transform.position = new Vector3(_positions[0].position.x + tempX * 2, _positions[0].position.y + tempY * 2, _positions[0].position.z);
            temp.transform.rotation = _positions[0].rotation;
            temp.transform.Find("Picture").GetComponent<Renderer>().material.mainTexture = images[i];
        }
    }
}
