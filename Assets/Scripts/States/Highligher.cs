using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highligher : MonoBehaviour
{
    private GameObject _currentTarget;
    private Material _originalMaterial;

    [SerializeField] private Material _highlightMaterial;

    private Dictionary<GameObject, Vector3> _localScales = new Dictionary<GameObject, Vector3>();

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green);

        Vector3 start = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(start, direction, out hit))
        {
            SetTarget(hit.transform.gameObject);
        }
        else
        {
            SetTarget(null);
        }
    }

    private void SetTarget(GameObject newTarget)
    {
        if (newTarget == _currentTarget)
        {
            return;
        }

        UnFocusTarget(_currentTarget);
        _currentTarget = newTarget;
        StoreLocalScale(_currentTarget);
        FocusTarget(_currentTarget);
    }

    private void StoreLocalScale(GameObject target)
    {
        if (target == null || _localScales.ContainsKey(target))
        {
            return;
        }

        _localScales.Add(target, target.transform.localScale);
    }

    private void UnFocusTarget(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        target.GetComponent<Renderer>().material = _originalMaterial;
    }

    private void FocusTarget(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        Renderer renderer = target.GetComponent<Renderer>();
        _originalMaterial = renderer.material;
        renderer.material = _highlightMaterial;
    }
}