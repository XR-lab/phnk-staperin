using CM.UI;
using UnityEngine;
using Valve.VR;

public class ChangeMenu : MonoBehaviour
{
	private CM_UI_System_ScreenRotation _uiSystemScreenRotation;

	private void Awake()
	{
		_uiSystemScreenRotation = GetComponent<CM_UI_System_ScreenRotation>();
	}

	private void Update()
	{
		if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.LeftHand))
			_uiSystemScreenRotation.NextScreen();
	}
}