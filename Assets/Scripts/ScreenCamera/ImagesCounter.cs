using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesCounter : MonoBehaviour {

    private int _counter = 0;

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
        //_counter = 0; // add this code to reset the counter
    }
}
