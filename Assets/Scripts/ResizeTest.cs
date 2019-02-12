using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeTest : MonoBehaviour
{
    private GameObject _target;

    private Vector3 _forward;

    private float _minSize = 0.1f;
    private float _maxSize = 2f;
    private float _value;
    private float _range;
    private float _amount = 0.5f; 

    private int _layerMask;

    void Start()
    {
        _layerMask = ~LayerMask.GetMask("Unscalable");
        _forward = transform.TransformDirection(Vector3.back);
        
        RaycastHit _hit;
        Ray _ray = new Ray(transform.position, _forward);

        Debug.DrawRay(transform.position, _forward, Color.red);

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider == null)
            {
                return;
            }
            Debug.Log(_hit.collider.name);
        }
    }

    void Update() 
    {
        if (Input.GetKey(KeyCode.Space)) //alleen als je trigger ingedrukt houdt
        {
            RaycastHit _hit;
            Ray _ray = new Ray(transform.position, _forward);

            Debug.DrawRay(transform.position, _forward, Color.red);

            if (Physics.Raycast(_ray, out _hit, -_layerMask))
            {
                if (_hit.collider == null)
                {
                    return;
                }
                CheckTarget(GameObject.Find(_hit.collider.name));
            }

            if (Input.GetKey(KeyCode.RightArrow))  //verander via rotation van arm band
            {
                if (_target == null)
                {
                    return;
                }
                _amount += 0.05f;
            }

            if (Input.GetKey(KeyCode.LeftArrow))  //verander via rotation van arm band
            {
                if (_target == null)
                {
                    return;
                }
                _amount -= 0.05f;
            }

            _amount = Mathf.Clamp01(_amount);
            //Debug.Log("amount: " + _amount);

            _value = (_minSize + (_maxSize - _minSize) * _amount);
            //_range = (_value - _minSize) / (_maxSize - _minSize);
            //Debug.Log((_value - _minSize) / (_maxSize - _minSize));
            ChangeSize(_value);
        }
    }

    void CheckTarget(GameObject _newTarget)
    {
        if (_newTarget.transform.parent != null)
        {
            _newTarget = GameObject.Find(_newTarget.transform.parent.name);
        }

        SetTarget(_newTarget);
    }

    void SetTarget(GameObject _newTarget)
    {
        _target = _newTarget;
    }

    void ChangeSize(float _scale)
    {
        _target.transform.localScale = new Vector3(_scale, _scale, _scale);
    }
}
