using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteData : MonoBehaviour {
	private string _saveFolder;
	private string _save;

	private GameObject timer;

	private void Start() {
		_saveFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/Saves/";
		_save = _saveFolder + "save.json";
		timer = gameObject;
		Init();

		if (new FileInfo(_save).Length == 0) {
			File.WriteAllText(_save, timer.GetComponent<Converter>().GetData());

		}
	}

	private void Init() {
		if (!Directory.Exists(_saveFolder)) {
			Directory.CreateDirectory(_saveFolder);
		}

		if (!File.Exists(_save)) {
			File.Create(_save).Dispose();
		}
	}
}
