using UnityEngine;
using Valve.VR;

public class ChangeStateOnRotation : MonoBehaviour
{
	public RotationChecker rotationChecker;

    [SerializeField] private InteractionMachine _interactionMachine;

    // todo: updaten deze regel
    public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");

    private void Start()
	{
		rotationChecker.RotationEvent += OnRotation;

        grabGripAction.AddOnChangeListener(OnGrip, SteamVR_Input_Sources.LeftHand);


    }

    private void OnGrip(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool isDown)
    {
        Debug.Log("Grip is: " + isDown);

        if (isDown)
        {

        }
    }

    private void OnRotation(Vector3 rotation)
	{
        var amount = ((360 - rotation.z) / 360 + 0.5f) % 1;
        
        _interactionMachine.Apply(amount);
	}
}