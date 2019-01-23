using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : State<InteractionStates>
{
    private GameObject _target;

    private Vector3 _forward;

    private float _distance;

    public override InteractionStates Id => InteractionStates.Resize;

    public override void Enter()
    {

        _forward = transform.TransformDirection(Vector3.forward);

        RaycastHit _hit;
        Ray _ray = new Ray(transform.position, _forward);

        Debug.DrawRay(transform.position, _forward, Color.red);

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider != null)
            {
                return;
            }
            Debug.Log("hit: " + _hit.collider);
        }
    }

    public override void Apply(float amount)
    {
        print("Apply called with amount" + amount);
    }

    void SetTarget()
    {

    }

    void ChangeSize()
    {

    }
}