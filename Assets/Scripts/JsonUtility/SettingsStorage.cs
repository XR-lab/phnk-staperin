using System.IO;

/// <summary>
/// Class for creating, saving and loading Json files. File and folder get automaticly created if they dont exsist. 
/// To use this class declare as the following:
/// SettingsStorage<"instert type"> st = new SettingsStorage<"insert same type">(desired path to file, new "insert same type"());
/// You can request data by: st.Data.someRandomData
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
		Load(_data);
	}

	public void Load(T data) {
		Converter<T> converter = new Converter<T>(_data);
		data = converter.GetDataFromJson();
	}

	private void Save() {
		Converter<T> converter = new Converter<T>(_data);
		File.WriteAllText(_saveFilePath, converter.GetDataToJson());
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
