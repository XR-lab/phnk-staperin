using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class RotationChecker : MonoBehaviour
{
	public bool thisRotation = false;

	[HideIf("thisRotation")]
	public Transform target;

	public delegate void RotationHandler(Quaternion rotation);
	public event RotationHandler rotationEvent;

	public UnityEvent onRotation;

	private Quaternion _rotationPrevious;

	private void Start()
	{
		if (thisRotation)
			target = transform;
	}

	private void Update()
	{
		if (target.transform.rotation != _rotationPrevious)
		{
			rotationEvent?.Invoke(target.transform.rotation);
			onRotation?.Invoke();
		}

		//_interactionMachine.SetState(InteractionStates.TimeTravel);
		//_interactionMachine.Apply(_slider.value);

		_rotationPrevious = target.transform.rotation;
	}
}