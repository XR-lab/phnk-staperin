using UnityEngine;

public class DayNightCycle : State<InteractionStates>
{
    public override InteractionStates Id => InteractionStates.DayNight;

    [SerializeField] private Debugger debugger;
    [SerializeField] private RotateAround _rotateAround;
    [SerializeField] private ColourGrading _colorGrading;
    [SerializeField] private ColourGrading _colorGradingCam2;

	public override void Apply(float amount) {
        debugger.ChangeDebugText("DayNightCycle Apply works");
        _rotateAround.Range = amount;
        _colorGrading.ColorGradient = amount;
        _colorGradingCam2.ColorGradient = amount;
	}
}