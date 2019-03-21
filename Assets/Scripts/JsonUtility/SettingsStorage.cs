using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class SettingsStorage<T> {
	private string _saveFolder;
	private string _saveFile;
	private T _data;

	public T Data {
		get { return _data; }
		set { Data = value; }
	}

	public SettingsStorage(string filePath, string fileName, T t) {
		_saveFolder = filePath;
		_saveFile = fileName;
		_data = t;
		InitializeSave();
		LoadJson(_saveFile, _data);
	}

	public void LoadJson(string location, T data) {
		string filePath = Path.Combine(Application.dataPath + _saveFile);

		try {
			using (StreamReader saveReader = new StreamReader(_saveFile)) {
				string json = saveReader.ReadToEnd();
				data = JsonUtility.FromJson<T>(json); ;
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

			if (File.Exists(_saveFile)) {
				outcome = true;
			} else {
				outcome = false;
			}

			succeeded = outcome;
			await Task.Delay(1000);
		}
		return succeeded;
	}

	private async void Save() {
		Converter<T> converter = new Converter<T>(_data);
		await WaitForFileData();

		if (new FileInfo(_saveFile).Length == 0) {
			File.WriteAllText(_saveFile, converter.GetSettingsJson());
		}

	}

	private void InitializeSave() {
		if (!Directory.Exists(_saveFolder)) {
			Directory.CreateDirectory(_saveFolder);
		}

		if (!File.Exists(_saveFile)) {
			File.Create(_saveFile).Dispose();
		}

		Save();
	}
}
