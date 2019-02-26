using UnityEngine;
using Valve.VR;

public class StateChangeTrigger : MonoBehaviour
{
	public RotationChecker rotationChecker;

    public SteamVR_Action_Boolean grabGripAction;

    private void Start()
	{
		grabGripAction.AddOnChangeListener(OnGrip, SteamVR_Input_Sources.LeftHand);
    }

    private void OnGrip(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool isDown)
    {
        rotationChecker.IsApplying = isDown;
    }

}