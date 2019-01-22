using CM.UI;
using UnityEngine;
using Valve.VR;

public class ChangeMenu : MonoBehaviour
{
	private CM_UI_System_ScreenRotation _uiSystemScreenRotation;

    public SteamVR_Action_Boolean teleportAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");

    private void Awake()
	{
		_uiSystemScreenRotation = GetComponent<CM_UI_System_ScreenRotation>();
	}

	private void Update()
	{
        if (teleportAction.GetState(SteamVR_Input_Sources.LeftHand))
			_uiSystemScreenRotation.NextScreen();
	}
}