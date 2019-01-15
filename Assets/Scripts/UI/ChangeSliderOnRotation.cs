using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ChangeSliderOnRotation : MonoBehaviour
{
	public RotationChecker rotationChecker;

	public enum EQuaternion { X, Y, Z, W };
	public EQuaternion rotationAxis = EQuaternion.X;

	private Slider _slider;

	private void Awake()
	{
		_slider = GetComponent<Slider>();
	}

	private void Start()
	{
		rotationChecker.rotationEvent += OnRotation;
	}

	private void OnRotation(Quaternion rotation)
	{
		if (rotationAxis == EQuaternion.X)
			_slider.value = rotation.eulerAngles.x/360;


		if (rotationAxis == EQuaternion.Y)
			_slider.value = Mathf.InverseLerp(0, 360, rotation.eulerAngles.y);
		if (rotationAxis == EQuaternion.Z)
			_slider.value = Mathf.InverseLerp(0, 360, rotation.eulerAngles.z);
		//if (rotationAxis == EQuaternion.W)
			//_slider.value = Mathf.InverseLerp(-0.7f, 0.7f, rotation.eulerAngles.w);
	}
}