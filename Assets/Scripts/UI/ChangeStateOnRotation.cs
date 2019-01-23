using UnityEngine;

public class ChangeStateOnRotation : MonoBehaviour
{
	public RotationChecker rotationChecker;

    [SerializeField] private InteractionMachine _interactionMachine;

	private void Start()
	{
		rotationChecker.RotationEvent += OnRotation;
	}

	private void OnRotation(Vector3 rotation)
	{
		_interactionMachine.Apply(((360 - rotation.z) / 360 + 0.5f) % 1);
	}
}