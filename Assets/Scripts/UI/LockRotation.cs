using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
	public RotationChecker rotationChecker;

	public bool lockX = false;
	public bool lockY = false;
	public bool lockZ = false;

	private void Start()
	{
		rotationChecker.RotationEvent += OnRotation;
		OnRotation(new Quaternion());
	}

	private void OnRotation(Quaternion rotation)
	{
		Vector3 newRotation = new Vector3();

		if (lockX)
			newRotation.Set(0, transform.eulerAngles.y, transform.eulerAngles.z);
		if (lockY)
			newRotation.Set(transform.eulerAngles.x, 0, transform.eulerAngles.z);
		if (lockZ)
			newRotation.Set(transform.eulerAngles.x, transform.eulerAngles.y, 0);

		transform.eulerAngles = newRotation;
	}
}