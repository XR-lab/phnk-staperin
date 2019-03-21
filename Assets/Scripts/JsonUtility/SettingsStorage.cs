using System.IO;
using System.Threading.Tasks;

/// <summary>
/// Class for creating, saving and loading Json files. Files and folder get automaticly created if they dont exsist. 
/// To use this class declare as the following:
/// SettingsStorage<"instert type"> st = new SettingsStorage<"insert same type">(desired path to file, new "insert same type"());
///	You can request data by: st.Data.someRandomData
/// </summary>

public class SettingsStorage<T> {
	private string _saveFolder;
	private string _saveFilePath;
	private T _data;

	public T Data {
		get { return _data; }
		set { Data = value; }
	}

	public SettingsStorage(string filePathAndName, T fileType) {
		_saveFilePath = filePathAndName;	
		_saveFolder = Path.GetDirectoryName(_saveFilePath);
		_data = fileType;
		InitializeSave();
		Load(_saveFilePath, _data);
	}

	public void Load(string location, T data) {
		Converter<T> converter = new Converter<T>(_data);
		data = converter.GetDataFromJson();
	}

	private async void Save() {
		Converter<T> converter = new Converter<T>(_data);
		await WaitForFileData();

		if (new FileInfo(_saveFilePath).Length == 0) {
			File.WriteAllText(_saveFilePath, converter.GetDataToJson());
		}

	}

	async Task<bool> WaitForFileData() {
		bool succeeded = false;

		while (!succeeded) {
			bool outcome;

			if (File.Exists(_saveFilePath)) {
				outcome = true;
			} else {
				outcome = false;
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

		if (!File.Exists(_saveFilePath)) {
			File.Create(_saveFilePath).Dispose();
		}

		Save();
	}
}
