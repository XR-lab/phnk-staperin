using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopGame : MonoBehaviour
{
    private ImagesCounter _counter;

    private void Awake()
    {
        _counter = FindObjectOfType<ImagesCounter>();
        _counter.LoadCounter();
        Debug.Log(_counter.Counter);
    }
}
