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
		Vector3 newRotation = new Vector3
		{
			x = (lockX) ? 0 : transform.eulerAngles.x,
			y = (lockY) ? 0 : transform.eulerAngles.y,
			z = (lockZ) ? 0 : transform.eulerAngles.z
		};

		transform.eulerAngles = newRotation;
	}
}