using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
	private Light _light;

	private float _time;
	private float _realTime;
	private float _step;
	private float _lastRange;

	public float Range { get; set; }

	[SerializeField]
	private GameObject cube;
	private Transform _copy;

	private Vector3 _startPos = new Vector3(0, 0, 0);
	private Vector3 _anchorOne = new Vector3(1f, 2, 0);
	private Vector3 _anchorTwo = new Vector3(2f, 2, 0);
	private Vector3 _endPos = new Vector3(3f, 0, 0);

	void Start()
	{
		_light = GetComponent<Light>();
		_lastRange = Range;
	}

	void Update()
	{
		if (Range == _lastRange)
		{
			return;
		}
		ChangeTime();
		_lastRange = Range;
		
		var bezierPos = BezierCurve.BezierPathCalculation(_startPos, _anchorOne, _anchorTwo, _endPos, Mathf.Min(Range * 2, 1));

		_light.intensity = bezierPos.y;
	}

	private void ChangeTime()
	{
		_time += _step;
		RotateObject(Range * 360);
	}

	public void RotateObject(float x)
	{
		transform.rotation = Quaternion.Euler(new Vector3(x, 90, 0));
	}
}
