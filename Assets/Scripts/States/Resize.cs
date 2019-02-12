using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : State<InteractionStates>
{
    private GameObject _target;

    private Vector3 _forward;

    private float _minSize = 0.1f;
    private float _maxSize = 2f;
    private float _value;
    private float _range;
    private float _amount = 0f;

    private int _layerMask;

    public override InteractionStates Id => InteractionStates.Resize;

    public override void Enter()
    {
        _layerMask = ~LayerMask.GetMask("Unscalable");
        _forward = transform.TransformDirection(Vector3.back);

        RaycastHit _hit;
        Ray _ray = new Ray(transform.position, _forward);

        if (Physics.Raycast(_ray, out _hit))
        {
            Debug.Log(_hit.collider.name);
            if (_hit.collider == null)
            {
                return;
            }
        }
    }

    public override void Apply(float amount)
    {
        if (Input.GetKey(KeyCode.Space)) //alleen als je trigger ingedrukt houdt
        {
            CastRay();
        }
    }

    void CastRay()
    {
        RaycastHit _hit;
        Ray _ray = new Ray(transform.position, _forward);

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

        _value = (_minSize + (_maxSize - _minSize) * _amount);
        //_range = (_value - _minSize) / (_maxSize - _minSize);
        ChangeSize(_value);
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

    void ChangeSize(float _growth)
    {
        Vector3 _change = new Vector3(_growth, _growth, _growth);
        Vector3 _currentSize = (_target.transform.localScale);
        Vector3 _newSize = _currentSize += _change;

        if (_newSize.z <= _minSize)
        {
            return;
        }

        if (_newSize.z >= _maxSize)
        {
            return;
        }
        _target.transform.localScale = _newSize;
    }
}