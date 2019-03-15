using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour {
	private Data _dt;
	private string _jsonData;
	private void Start() {
		_dt = new Data();
		_jsonData = JsonUtility.ToJson(_dt);
	}

	public string GetData() {
		return _jsonData;
	}
}
