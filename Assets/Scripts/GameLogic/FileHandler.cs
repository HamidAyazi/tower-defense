using System.IO;
using UnityEngine;
using Newtonsoft.Json;

/// <summary>
/// This class is used to save and load data to/from system's persistent data path.
/// </summary>
public class FileHandler
{
    private static string DataPath = Application.persistentDataPath;

    /// <summary>
    /// <c>SaveData</c> uses Newtonsoft.Json to save any object to system's persistent data path as a Json file.
    /// </summary>
    /// <typeparam name="T">Type of the object that is wanted to be saved.</typeparam>
    /// <param name="data">Object to save.</param>
    /// <param name="fileName">Name of the saving file.</param>
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
            Debug.LogError("Error occurred when trying to save data:\n" + e.Message);
        }
    }
    /// <summary>
    /// <c>LoadData</c> uses Newtonsoft.Json to load any Json file from system's persistent data path.
    /// </summary>
    /// <typeparam name="T">Type of the object that is wanted to be loaded.</typeparam>
    /// <param name="fileName">Name of the file.</param>
    /// <returns>Deserialized object of type <c>T</c>.</returns>
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
