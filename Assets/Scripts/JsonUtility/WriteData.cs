using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class WriteData : MonoBehaviour {
	private string _saveFolder;
	private string _save;

	private GameObject timer;

	private async void Start() {
		_saveFolder = Application.dataPath + @"\zet_tijd\";
		_save = _saveFolder + "tijd.json";
		timer = gameObject;
		Init();
		await WaitForFileData();
	}

	async Task<bool> WaitForFileData() {
		bool succeeded = false;
		while (!succeeded) {
			bool outcome;

			if (new FileInfo(_save).Length == 0) {
				File.WriteAllText(_save, timer.GetComponent<Converter>().GetData());
				outcome = false;
			} else {
				outcome = true;
			}

			succeeded = outcome;
			await Task.Delay(1000);
		}
		return succeeded;
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
