using System;
using System.Collections.Generic;
using CM.UI;
using UnityEngine;
using Valve.VR;

public class ChangeInteractionState : MonoBehaviour
{
	private CM_UI_System_ScreenRotation _uiSystemScreenRotation;
    private Dictionary<string, InteractionStates> _interactionStates;

    public SteamVR_Action_Boolean trackpadAction;

    private void Awake()
	{
		_uiSystemScreenRotation = GetComponent<CM_UI_System_ScreenRotation>();
        
        trackpadAction.AddOnChangeListener(OnTrackPadDownOrUp, SteamVR_Input_Sources.LeftHand);
  
    }

    private void OnTrackPadDownOrUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool isDown)
    {
        if (isDown) {
            var currentScreen = _uiSystemScreenRotation.NextScreen();
            var currentState = _interactionStates[currentScreen.name];
        }
    }

}