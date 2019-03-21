﻿using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Class for creating, saving and loading Json files. Files get automaticly created if they dont exsist. 
/// To use this class declare as the following:
/// SettingsStorage<"instert type"> st = new SettingsStorage<"insert same type">(desired path to file, new ("insert same type")());
///	You can request data by: st.Data.someRandomData
/// </summary>

public class SettingsStorage<T> {
	private string _saveFolder;
	private string _saveFile;
	private T _data;

	public T Data {
		get { return _data; }
		set { Data = value; }
	}

	public SettingsStorage(string filePathAndName, T fileType) {
		_saveFile = filePathAndName;	
		_saveFolder = Path.GetDirectoryName(_saveFile);
		
		_data = fileType;
		InitializeSave();
		Load(_saveFile, _data);
	}

	public void Load(string location, T data) {
		Converter<T> converter = new Converter<T>(_data);
		data = converter.GetDataFromJson();
	}

	private async void Save() {
		Converter<T> converter = new Converter<T>(_data);
		await WaitForFileData();

		if (new FileInfo(_saveFile).Length == 0) {
			File.WriteAllText(_saveFile, converter.GetDataToJson());
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
