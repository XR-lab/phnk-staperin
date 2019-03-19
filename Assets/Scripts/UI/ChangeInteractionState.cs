using System;
using System.Collections.Generic;
using CM.UI;
using UnityEngine;
using Valve.VR;

public class ChangeInteractionState : MonoBehaviour
{
    public Debugger debugger;
	private CM_UI_System_ScreenRotation _uiSystemScreenRotation;
    private Dictionary<string, InteractionStates> _interactionStates = new Dictionary<string, InteractionStates>(){
        { "DayNightUI", InteractionStates.DayNight},
        { "HiddenLayerUI", InteractionStates.HiddenLayer},
        { "MagnifierUI", InteractionStates.Magnifier},
        { "ScalerUI", InteractionStates.Scaler}
    };

    public SteamVR_Action_Boolean trackpadAction;

    [SerializeField] private InteractionMachine _interactionMachine;

    private void Awake()
	{
        debugger = FindObjectOfType<Debugger>();
		_uiSystemScreenRotation = GetComponent<CM_UI_System_ScreenRotation>();
        
        trackpadAction.AddOnChangeListener(OnTrackPadDownOrUp, SteamVR_Input_Sources.LeftHand);
        debugger.AddDebugText("" + trackpadAction.state);
  
    }

    private void OnTrackPadDownOrUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool isDown)
    {
        debugger.ChangeDebugText("I'm here first!!!! ");
        if (isDown) {
            debugger.AddDebugText("I'm here!!!! ");
            var currentScreen = _uiSystemScreenRotation.NextScreen();
            var currentState = _interactionStates[currentScreen.name];
            _interactionMachine.SetState(currentState);
            debugger.AddDebugText("Next state: " + currentState + " ");
        }
    }

}