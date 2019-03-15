using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CM.UI;

public class KeyboardChangeState : MonoBehaviour
{
	//private readonly StateMachine<InteractionStates> _interactionMachine = new StateMachine<InteractionStates>();
	[SerializeField] private InteractionMachine _interactionMachine;
	private CM_UI_System_ScreenRotation _uiSystemScreenRotation;
	private Dictionary<string, InteractionStates> _interactionStates = new Dictionary<string, InteractionStates>(){
		{ "DayNightUI", InteractionStates.DayNight},
		{ "HiddenLayerUI", InteractionStates.HiddenLayer},
		{ "MagnifierUI", InteractionStates.Magnifier},
		{ "ScalerUI", InteractionStates.Scaler}
	};

	void Awake(){
		_uiSystemScreenRotation = GetComponent<CM_UI_System_ScreenRotation>();
	}

    void Update(){
		bool _keyOne = Input.GetKeyDown(KeyCode.Alpha1);
		bool _keyTwo = Input.GetKeyDown(KeyCode.Alpha2);
		//bool _keyThree = Input.GetKeyDown(KeyCode.Alpha3);
		//bool _keyFour = Input.GetKeyDown(KeyCode.Alpha4);

		if(_keyOne){
			//_interactionMachine.SetState(InteractionStates.DayNight);
			NextState();
		}
		if(_keyTwo){
			//_interactionMachine.SetState(InteractionStates.HiddenLayer);
			PreviousState();
		}/*
		if(_keyThree){
			_interactionMachine.SetState(InteractionStates.Magnifier);
		}
		if(_keyFour){
			_interactionMachine.SetState(InteractionStates.Scaler);
		}*/
    }

	private void NextState(){
		var currentScreen = _uiSystemScreenRotation.NextScreen();
		var currentState = _interactionStates[currentScreen.name];
		_interactionMachine.SetState(currentState);
		print("Switched to: " + currentState);
	}

	private void PreviousState(){
		var previousScreen = _uiSystemScreenRotation.PreviousScreen();
		var previousState = _interactionStates[previousScreen.name];
		print("switching to: " + previousState);
		_interactionMachine.SetState(previousState);
	}
}
