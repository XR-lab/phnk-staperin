using UnityEngine;

public class Converter<T> {
	private T _dataType;
	private string _jsonData;

	public Converter(T dataType) {
		_dataType = dataType;
	}

	public string GetDataToJson() {
		_jsonData = JsonUtility.ToJson(_dataType);
		return _jsonData;
	}

	public T GetDataFromJson() {
		T data = JsonUtility.FromJson<T>(_jsonData); ;
		return data;
	}
}
