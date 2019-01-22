using CM.UI;
using UnityEngine;

public class ChangeMenu : MonoBehaviour
{
	public KeyCode key;

	private CM_UI_System_ScreenRotation _uiSystemScreenRotation;

	private void Awake()
	{
		_uiSystemScreenRotation = GetComponent<CM_UI_System_ScreenRotation>();

		for (int i = 0; i < Input.GetJoystickNames().Length; i++)
			Debug.Log(Input.GetJoystickNames()[i]);
	}

	private void Update()
	{
		if (Input.GetKeyDown(key))
			_uiSystemScreenRotation.NextScreen();
	}
}