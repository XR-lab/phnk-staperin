using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : State<InteractionStates>
{
    private GameObject _target;

    [SerializeField]
    private GameObject _rayCaster;

    private Vector3 _forward;

    private float _minSize = 0.1f;
    private float _maxSize = 2f;
    private float _value;
    private float _range;
    private float _amount = 0f;

    private int _layerMask;

    public override InteractionStates Id => InteractionStates.Scaler;

    public override void Enter()
    {
        _layerMask = ~LayerMask.GetMask("Unscalable");
        _forward = _rayCaster.transform.TransformDirection(Vector3.forward);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //alleen als je trigger ingedrukt houdt
        {
            CastRay();
        }
    }

    public override void Apply(float amount)
    {
        Debug.Log("applying scale");
        
        if (_target == null)
        {
            return;
        }

        Debug.Log(_target.name);

        _value = (_minSize + (_maxSize - _minSize) * _amount);

        ChangeSize(_value);
    }

    void CastRay()
    {
        RaycastHit _hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        
        Debug.DrawRay(_rayCaster.transform.position, _rayCaster.transform.forward * 10, Color.green);

        Ray _ray = new Ray(_rayCaster.transform.position, transform.forward);

        if (Physics.Raycast(_ray, out _hit, -_layerMask))
        {
            Debug.Log(_hit.collider.name);
            if (_hit.collider == null)
            {
                return;
            }
            CheckTarget(GameObject.Find(_hit.collider.name));
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

    void ChangeSize(float _newSize)
    {
        
        _target.transform.localScale = new Vector3(_newSize, _newSize, _newSize);
    }
}