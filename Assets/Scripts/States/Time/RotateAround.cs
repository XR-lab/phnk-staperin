﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

    [SerializeField] private Debugger _debugger;
    [SerializeField] private float _range;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _minAngle;

	public float Range
    {
        get
        {
            return _range;
        }
        set
        {
            _range = value;
            UpdateTime();
        }
    }

    private void Start()
    {
        _debugger = FindObjectOfType<Debugger>();
    }

    private void UpdateTime()
    {
        var width = _maxAngle - _minAngle;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, _minAngle + Range * width));
        _debugger.ChangeDebugText("New Value: " + width);
    }

}
