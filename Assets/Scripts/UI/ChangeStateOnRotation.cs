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
		rotationChecker.rotationEvent += OnRotation;
	}

	private void OnRotation(Quaternion rotation)
	{
		_interactionMachine.SetState(InteractionStates.TimeTravel);
		_interactionMachine.Apply(rotation.eulerAngles.x / 360);
	}
}