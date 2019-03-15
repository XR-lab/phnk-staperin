using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class ReadData : MonoBehaviour {
	private GameObject _timer;
	private string _save;
	private Data _data;

	private void Start() {
		_timer = this.gameObject;
		_save = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\Saves\\save.json";
		LoadJson(_save, _data);
	}

	public void LoadJson(string location, Data data) {
		using (StreamReader r = new StreamReader(_save)) {
			string json = r.ReadToEnd();
			data = JsonConvert.DeserializeObject<Data>(json);
		}
	}

	public int GetGameTime() {
		return _data.GameTime;
	}

	public int GetSwitchTime() {
		return _data.SwitchTime;
	}
}
