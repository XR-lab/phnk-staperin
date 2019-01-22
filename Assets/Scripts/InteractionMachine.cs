using UnityEngine;

public class InteractionMachine : MonoBehaviour
{
    private readonly StateMachine<InteractionStates> _interactionMachine = new StateMachine<InteractionStates>();
    private float _time = 0;

    private void Start()
    {
        InitializeStates();

        // testing:
        SetState(InteractionStates.TimeTravel);

    }

    private void Update()
    {
        _time += 0.001f;
        Apply(_time);
        if (_time > 1)
            _time = 0;
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