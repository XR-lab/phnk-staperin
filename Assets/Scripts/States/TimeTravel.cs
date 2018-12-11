public class TimeTravel : State<InteractionStates>
{
    public override InteractionStates Id => InteractionStates.TimeTravel;

    public override void Apply()
    {
        print("Apply called");
    }
}