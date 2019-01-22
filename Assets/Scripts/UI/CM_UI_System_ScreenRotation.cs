using UnityEngine;
using UnityEngine.UI;

namespace CM.UI
{
	public class CM_UI_System_ScreenRotation : MonoBehaviour
	{
		private CM_UI_System _uiSystem;

		private Component[] _screens;
		private int _screenIndex = 0;

		private void Awake()
		{
			_uiSystem = GetComponent<CM_UI_System>();
		}

		private void Start()
		{
			_uiSystem.InitializeScreensEvent += OnInitializeScreens;
		}

		private void OnInitializeScreens(Component[] screens)
		{
			_screens = screens;
		}

		public void NextScreen()
		{
			_screenIndex = (_screenIndex < _screens.Length-1) ? ++_screenIndex : 0;
			_uiSystem.SwitchScreens(_screens[_screenIndex].GetComponent<CM_UI_Screen>());
		}

		public void PreviousScreen()
		{
			_screenIndex = (_screenIndex > 0) ? --_screenIndex : _screens.Length-1;
			_uiSystem.SwitchScreens(_screens[_screenIndex].GetComponent<CM_UI_Screen>());
		}
	}
}