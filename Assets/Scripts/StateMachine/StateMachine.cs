using System.Collections.Generic;

public class StateMachine<TStateId>
{
    private readonly Dictionary<TStateId, State<TStateId>> _states = new Dictionary<TStateId, State<TStateId>>();

    private State<TStateId> _currentState;

    public void Apply(float amount)
    {
        _currentState?.Apply(amount);
    }

    /// <summary>
    /// Method om de state te wijzigen
    /// </summary>
    public void SetState(TStateId stateId)
    {
        if (!_states.ContainsKey(stateId))
            return;

        _currentState?.Leave();

        _currentState = _states[stateId];

        _currentState.Enter();
    }

    /// <summary>
    /// Voeg een state toe aan de state machine
    /// </summary>
    /// <param name="stateId">Een integer die komt uit de ENUM StateID</param>
    /// <param name="state">Een component die State.cs extend (inheritance)</param>
    public void AddState(TStateId stateId, State<TStateId> state)
    {
        _states.Add(stateId, state);
    }
}