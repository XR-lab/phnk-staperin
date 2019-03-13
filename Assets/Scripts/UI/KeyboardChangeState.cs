using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardChangeState : MonoBehaviour
{
	private InteractionMachine _interactionMachine;

	void Start(){
		_interactionMachine = gameObject.GetComponent<InteractionMachine>();
	}

    void Update(){
		bool _keyOne = Input.GetKeyDown(KeyCode.Alpha1);
		bool _keyTwo = Input.GetKeyDown(KeyCode.Alpha2);
		bool _keyThree = Input.GetKeyDown(KeyCode.Alpha3);
		bool _keyFour = Input.GetKeyDown(KeyCode.Alpha4);

		if(_keyOne){
			_interactionMachine.SetState(InteractionStates.DayNight);
		}
		if(_keyTwo){
			_interactionMachine.SetState(InteractionStates.HiddenLayer);
		}
		if(_keyThree){
			_interactionMachine.SetState(InteractionStates.Magnifier);
		}
		if(_keyFour){
			_interactionMachine.SetState(InteractionStates.Scaler);
		}
    }
}
