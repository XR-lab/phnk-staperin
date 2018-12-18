using UnityEngine;

public class PaintEffect : State<InteractionStates>
{
    [SerializeField] private Material _paintMaterial;

    public override InteractionStates Id => InteractionStates.PaintEffect;
    public Material TargetMaterial => _paintMaterial;

    public override void Apply()
    {
    }
}