using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {
	private Light _light;
	private float _time;
	private float _realTime;
	private float _step;

	//rotatie = uur * stap(360/24)

    void Start() {
	    _light = GetComponent<Light>();
	    _step = 360 / 24;
	    _realTime = 18;
    }

    void Update()
    {

	    if (Input.GetKeyDown(KeyCode.Space)) {
			ChangeTime();
		}
    }

	/*private void Move(float angle) {
		transform.Rotate(0, angle, 0);
	}*/

	private void ChangeTime() {
		_time += _step;
		RotateObject(_time%360);
		print(_time%360);
	}

	public void RotateObject(float x) {
		transform.rotation = Quaternion.Euler(new Vector3(x, 90, 0));
	}
}
