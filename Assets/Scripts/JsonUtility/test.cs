using UnityEngine;

public class test : MonoBehaviour {
	SettingsStorage<Settings> st;

	void Start() {
		string path;
		st = new SettingsStorage<Settings>(path = Application.dataPath + @"/zet_tijd", path + @"/tijd.json", new Settings());
		Debug.Log(st.Data.GameTime);
	}
}
