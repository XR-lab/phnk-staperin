using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeTest : MonoBehaviour
{
    private GameObject _target;

    private Vector3 _forward;
    private Vector3 _minSize = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 _maxSize = new Vector3(2, 2, 2);

    private float _distance;

    void Start()
    {
        _forward = transform.TransformDirection(Vector3.back);
        
        RaycastHit _hit;
        Ray _ray = new Ray(transform.position, _forward);

        Debug.DrawRay(transform.position, _forward, Color.red);

        if (Physics.Raycast(_ray, out _hit))
        {
            Debug.Log(_hit.collider.name);
            if (_hit.collider == null)
            {
                return;
            }
        }
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit _hit;
            Ray _ray = new Ray(transform.position, _forward);

            Debug.DrawRay(transform.position, _forward, Color.red);

            if (Physics.Raycast(_ray, out _hit))
            {
                if (_hit.collider == null)
                {
                    return;
                }
                SetTarget(GameObject.Find(_hit.collider.name));
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (_target == null)
            {
                return;
            }

            ChangeSize(0.1f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))  //verander via rotation van arm band
        {
            if (_target == null)
            {
                return;
            }

            ChangeSize(-0.1f);
        }
    }

    void SetTarget(GameObject _newTarget)
    {
        _target = _newTarget;
    }

    void ChangeSize(float _growth)
    {
        Vector3 _change = new Vector3(_growth, _growth, _growth);
        Vector3 _currentSize = (_target.transform.localScale);
        Vector3 _newSize = _currentSize += _change;

        if (_newSize.z <= _minSize.z)
        {
            return;
        }

        if (_newSize.z >= _maxSize.z)
        {
            return;
        }

        _target.transform.localScale = _newSize;
    }
}
