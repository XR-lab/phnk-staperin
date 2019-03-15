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
		LoadJson();
	}

	public void LoadJson() {
		using (StreamReader r = new StreamReader(_save)) {
			string json = r.ReadToEnd();
			_data = JsonConvert.DeserializeObject<Data>(json);
		}
	}

	public int GetSeconds() {
		return _data.Seconds;
	}

	public int GetTransferTime() {
		return _data.TransferTime;
	}
}
