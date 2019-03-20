using UnityEngine;

public class Converter {
	private Settings _settings;
	private string _jsonData;

	public Converter() {
		_settings = new Settings();
		_jsonData = JsonUtility.ToJson(_settings);
	}

	public string GetSettingsJson() {
		return _jsonData;
	}
}
