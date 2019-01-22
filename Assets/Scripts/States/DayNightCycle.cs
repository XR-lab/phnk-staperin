using UnityEngine;

public class DayNightCycle : State<InteractionStates>
{
    public override InteractionStates Id => InteractionStates.TimeTravel;
	private RotateAround _rotateAround;
	private ColourGrading _colorGrading;

	public override void Enter() {
        _rotateAround = GameObject.Find("Area Light").GetComponent<RotateAround>();
        _colorGrading = GameObject.Find("Schilderij camera").GetComponent<ColourGrading>();
	}

	public override void Apply(float amount) {
        _rotateAround.Range = amount;
        _colorGrading.ColorGradient = amount;
	}
}