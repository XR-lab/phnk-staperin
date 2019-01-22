using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ChangeSliderOnRotation : MonoBehaviour
{
	public RotationChecker rotationChecker;

	public enum EQuaternion { X, Y, Z };
	public EQuaternion rotationAxis = EQuaternion.X;

	private Slider _slider;

	private void Awake()
	{
		_slider = GetComponent<Slider>();
	}

	private void Start()
	{
		rotationChecker.RotationEvent += OnRotation;
	}

	private void OnRotation(Quaternion rotation)
	{
		if (rotationAxis == EQuaternion.X)
			_slider.value = rotation.x;

		if (rotationAxis == EQuaternion.Y)
			_slider.value = rotation.y;

		if (rotationAxis == EQuaternion.Z)
			_slider.value = rotation.z;
	}
}