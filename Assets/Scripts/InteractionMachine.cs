using UnityEngine;

public class InteractionMachine : MonoBehaviour
{
    private readonly StateMachine<InteractionStates> _interactionMachine = new StateMachine<InteractionStates>();

    private void Start()
    {
        InitializeStates();

        // testing:
        //SetState(InteractionStates.TimeTravel);
        //Apply(1.0f);
    }

    private void InitializeStates()
    {
        var allStates = GetComponents<State<InteractionStates>>();
        foreach (var stateComponent in allStates)
        {
            _interactionMachine.AddState(stateComponent.Id, stateComponent);
        }
    }

    public void SetState(InteractionStates stateId)
    {
        _interactionMachine.SetState(stateId);
    }

    public void Apply(float amount)
    {
        _interactionMachine.Apply(amount);
    }
}