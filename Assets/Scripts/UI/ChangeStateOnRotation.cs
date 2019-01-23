using UnityEngine;

public class ChangeStateOnRotation : MonoBehaviour
{
	public RotationChecker rotationChecker;

	private InteractionMachine _interactionMachine;

	private void Awake()
	{
		_interactionMachine = GetComponent<InteractionMachine>();
	}

	private void Start()
	{
		rotationChecker.RotationEvent += OnRotation;
	}

	private void OnRotation(Vector3 rotation)
	{
		_interactionMachine.SetState(InteractionStates.TimeTravel);
		_interactionMachine.Apply(Mathf.InverseLerp(-1, 1, rotation.z));
	}
}