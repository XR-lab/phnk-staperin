using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class SettingsStorage : MonoBehaviour {
	private GameObject _timer;
	private readonly string _saveLocation = "zet_tijd\tijd.json";
	private string _saveFolder;
	private string _save;
	private Settings _data;

	private async void Start() {
		_timer = gameObject;
		_saveFolder = Application.dataPath + @"\zet_tijd\";
		_save = _saveFolder + "tijd.json";
		InitializeSave();
		//_saveLocation = Application.dataPath + @"\zet_tijd\tijd.json";
		LoadJson(_saveLocation, _data);
		await WaitForFileData();

	}

	public void LoadJson(string location, Settings data) {
		string filePath = Path.Combine(Application.dataPath + _saveLocation);

		try {
			using (StreamReader saveReader = new StreamReader(_saveLocation)) {
				string json = saveReader.ReadToEnd();
				data = JsonUtility.FromJson<Settings>(json); //JsonConvert.DeserializeObject<Settings>(json);
			}
		} catch (Exception e) {
			Debug.Log("File could not be read");
			Debug.Log(e.Message);

		}
	}

	async Task<bool> WaitForFileData() {
		bool succeeded = false;
		while (!succeeded) {
			bool outcome;

			if (new FileInfo(_save).Length == 0) {
				File.WriteAllText(_save, _timer.GetComponent<Converter>().GetSettingsJson());
				outcome = false;
			} else {
				outcome = true;
			}

			succeeded = outcome;
			await Task.Delay(1000);
		}
		return succeeded;
	}

	private void InitializeSave() {
		if (!Directory.Exists(_saveFolder)) {
			Directory.CreateDirectory(_saveFolder);
		}

		if (!File.Exists(_save)) {
			File.Create(_save).Dispose();
		}
	}

	public float GetGameTime() {
		return _data.GameTime;
	}

	public float GetSwitchTime() {
		return _data.SwitchTime;
	}
}
