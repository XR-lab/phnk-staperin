using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {
	[SerializeField] private GameObject _axis;


    // Start is called before the first frame update
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKey(KeyCode.D)) {
			Move(1);
		}

	    if (Input.GetKey(KeyCode.A)) {
			Move(-1);
		}

	    /*switch (Input.inputString) {
			case "d":
				transform.RotateAround(Vector3.zero, Vector3.forward, 1);
				print("D");
				break;

			case "a":
				transform.RotateAround(Vector3.zero, Vector3.forward, -1);
				break;
		}*/
	}

	private void Move(float angle) {
		transform.RotateAround(Vector3.zero, Vector3.forward, angle);
	}
}
