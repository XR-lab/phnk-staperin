using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	void Start() {
		SettingsStorage<Settings> st = new SettingsStorage<Settings>(Application.dataPath +@"\zet_tijd/tijd.json", new Settings());
	}

	// Update is called once per frame
	void Update() {

	}
}
