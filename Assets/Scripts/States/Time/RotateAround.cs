using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class RotateAround : MonoBehaviour
{


    [SerializeField]
    private float _range;

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


    private void UpdateTime()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Range * 360));
    }

}
