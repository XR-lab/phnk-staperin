using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class RotateAround : MonoBehaviour {
	private Light _light;

	private float _time;
	private float _realTime;
	private float _step;
	private float _lastRange;
	[Range(0f,1f)]
	public float range;


	public GameObject cube;
	private Transform _copy;

	Vector3 p0 = new Vector3(0, 0, 0);
	Vector3 p1 = new Vector3(1f, 2, 0);
	Vector3 p2 = new Vector3(2f, 2, 0);
	Vector3 p3 = new Vector3(3f, 0, 0);

	void Start() {
	    _light = GetComponent<Light>();
		_lastRange = range;
	}

    void Update()
    {
	    if (range == _lastRange) {
		    return;
	    } else {
			ChangeTime();
		    _lastRange = range;
	    }

	    if (_copy != null) {
		    Destroy(_copy.gameObject);
	    }

	    var p = BezierCurve.BezierPathCalculation(p0, p1, p2, p3, Mathf.Min(range*2, 1));
	    _copy = Instantiate(cube.transform, p, Quaternion.identity);

	    _light.intensity = _copy.transform.position.y;
    }

	private void ChangeTime() {
		_time += _step;
		RotateObject(range * 360);

		Debug.Log(BezierCurve.BezierPathCalculation(p0, p1, p2, p3, range));
	}

	public void RotateObject(float x) {
		transform.rotation = Quaternion.Euler(new Vector3(x, 90, 0));
	}
}
