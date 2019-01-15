using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SaveData(int count)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Images.count";
        FileStream stream = new FileStream(path, FileMode.Create);
        ImageCountData data = new ImageCountData(count);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ImageCountData LoadData()
    {
        string path = Application.persistentDataPath + "/Images.count";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ImageCountData data = formatter.Deserialize(stream) as ImageCountData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
