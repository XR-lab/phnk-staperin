using UnityEngine;

public class DayNightCycle : State<InteractionStates>
{
    public override InteractionStates Id => InteractionStates.TimeTravel;
	private RotateAround rot;
	private ColourGrading cg;

	public override void Enter() {
		RotateAround rot = GameObject.Find("Area Light").GetComponent<RotateAround>();
		ColourGrading cg = GameObject.Find("Schilderij camera").GetComponent<ColourGrading>();
	}

	public override void Apply(float amount) {
		rot.Range = amount;
		cg.Range = amount;
	}
}