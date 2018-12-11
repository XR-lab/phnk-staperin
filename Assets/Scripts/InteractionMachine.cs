using UnityEngine;

public class InteractionMachine : MonoBehaviour
{
    private readonly StateMachine<InteractionStates> _interactionMachine = new StateMachine<InteractionStates>();

    private void Start()
    {
        InitializeStates();
        _interactionMachine.SetState(InteractionStates.TimeTravel);
        _interactionMachine.Apply();
    }

    private void InitializeStates()
    {
        var allStates = GetComponents<State<InteractionStates>>();
        foreach (var stateComponent in allStates)
        {
            _interactionMachine.AddState(stateComponent.StateId, stateComponent);
        }
    }

}