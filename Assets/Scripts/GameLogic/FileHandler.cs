using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class FileHandler
{
    private static string DataPath = Application.persistentDataPath;

    public static void SaveData<T>(T data, string fileName)
    {
        string filePath = Path.Combine(DataPath, fileName);
        try
        {
            string serializedData = JsonConvert.SerializeObject(data); // Serialize using JsonConvert
            File.WriteAllText(filePath, serializedData);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error occurred when trying to save data: " + e.Message);
        }
    }

    public static T LoadData<T>(string fileName)
    {
        string filePath = Path.Combine(DataPath, fileName);
        if (File.Exists(filePath))
        {
            try
            {
                string serializedData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(serializedData); // Deserialize using JsonConvert
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error occurred when trying to load data: " + e.Message);
            }
        }

        return default(T);
    }
}
