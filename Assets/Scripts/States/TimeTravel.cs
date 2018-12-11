public class TimeTravel : State<InteractionStates>
{
    public override InteractionStates StateId => InteractionStates.TimeTravel;

    public override void Apply()
    {
        print("Apply called");
    }
}