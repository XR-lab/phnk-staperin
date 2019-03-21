using UnityEngine;

public class Converter<T> {
	private T _type;
	private string _jsonData;

	public Converter(T fileType) {
		_type = fileType;
		_jsonData = JsonUtility.ToJson(_type);
	}

	public string GetSettingsJson() {
		return _jsonData;
	}
}
