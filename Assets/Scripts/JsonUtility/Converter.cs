using UnityEngine;

public class Converter : MonoBehaviour {
	private Data _dt;
	private string _jsonData;
	private void Start() {
		_dt = new Data();
		_jsonData = JsonUtility.ToJson(_dt);
		Debug.Log(GetData() + "start");
	}

	public string GetData() {
		return _jsonData;
	}
}
