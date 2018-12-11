using UnityEngine;

public abstract class State<T> : MonoBehaviour
{
    
    public abstract T Id { get; }

    public virtual void Enter()
    {
    }

    public virtual void Leave()
    {
    }

    public abstract void Apply();
}