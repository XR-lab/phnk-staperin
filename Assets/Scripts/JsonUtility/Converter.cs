using UnityEngine;

public class Converter : MonoBehaviour {
	private Settings _settings;
	private string _jsonData;
	private void Start() {
		_settings = new Settings();
		_jsonData = JsonUtility.ToJson(_settings);
	}

	public string GetSettingsJson() {
		return _jsonData;
	}
}
