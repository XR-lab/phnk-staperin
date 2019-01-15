using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {
	private Light _light;
	private float _time;
	private float _realTime;
	private float _step;
	[Range(0f,1f)]
	public float _range;

	public GameObject cube;
	private Transform _copy;

    void Start() {
	    _light = GetComponent<Light>();
	    _step = 360 / 24;
	    _realTime = 18;

	   
	}

    void Update()
    {
	    ChangeTime();


	    var p0 = new Vector3(0, 0.1f, 0);
	    var p1 = new Vector3(0.1f, 2, 0);
	    var p2 = new Vector3(0.2f, 0.3f, 0);
	    var p3 = new Vector3(1f,-5 , 0);

	    if (_copy != null) {
		    Destroy(_copy);
	    }
	    //for (float i = 0; i < 100; i++) {
	    var p = BezierPathCalculation(p0, p1, p2, p3, _range);
	    _copy = Instantiate(cube.transform, p, Quaternion.identity);
	    //}

		/*if (Input.GetKeyDown(KeyCode.Space)) {
			ChangeTime();
		}*/

	    _light.intensity = _copy.transform.position.y;
    }

	private void ChangeTime() {
		_time += _step;
		//RotateObject(_time%360);
		RotateObject(_range * 360);

		//print(_time%360);

		Vector3 p0 = new Vector3(0.1f,0,0);
		Vector3 p1 = new Vector3(1f, 0, 0);
		Vector3 p2 = new Vector3(1f, 0, 0);
		Vector3 p3 = new Vector3(0.1f, 0, 0);

		Debug.Log(BezierPathCalculation(p0, p1, p2, p3, _range));
	}

	public void RotateObject(float x) {
		transform.rotation = Quaternion.Euler(new Vector3(x, 90, 0));
	}

	Vector3 BezierPathCalculation(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
		Debug.Log(t);
		float tt = t * t;
		float ttt = t * tt;
		float u = 1.0f - t;
		float uu = u * u;
		float uuu = u * uu;

		Vector3 B = new Vector3();
		B = uuu * p0;
		B += 3.0f * uu * t * p1;
		B += 3.0f * u * tt * p2;
		B += ttt * p3;

		return B;
	}
}
