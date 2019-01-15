public class TimeTravel : State<InteractionStates>
{
    public override InteractionStates Id => InteractionStates.TimeTravel;

    public override void Apply(float amount)
    {
        print("Apply called with amount" + amount);
    }
}