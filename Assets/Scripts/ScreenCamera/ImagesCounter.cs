using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesCounter : MonoBehaviour {

    private int _counter = 0;

    void Start()
    {
        LoadCounter();
    }

    public int Counter
    {
        get {
            return _counter;
        }
        set
        {
            _counter = value;
        }
    }

    public void SaveCounter()
    {
        SaveSystem.SaveData(_counter);
    }

    public void LoadCounter()
    {
        ImageCountData data = SaveSystem.LoadData();
        _counter = data.imageCount;
    }

    public void ResetCounter() //keep in mind if you do this function remove every image in the folder ScreenShots
    {
        _counter = 0;
        SaveCounter();
    }
}
