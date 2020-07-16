using System.IO;
using UnityEngine;

namespace Silicom.UI
{
    public abstract class UIBase : MonoBehaviour
    {

        private const string UI_DATA_FOLDER_NAME = "UI_Data";
        private const string FILE_EXTENSION = "json";

        protected static bool FetchedData;

        public string FetchData(string fileName)
        {
            string filePath = CombinePath(UI_DATA_FOLDER_NAME, fileName, FILE_EXTENSION);
            if (!File.Exists(filePath))
            {
                Debug.LogError($"FetchData - Could not load data file : '{filePath}' doesn't exist !", this);
                return string.Empty;
            }
            
            string json = File.ReadAllText(filePath);
            return json;
        }

        private static string CombinePath(string path, string fileName, string extension)
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, $"{path}");
            filePath = Path.Combine(filePath, $"{fileName}.{extension}");
            return filePath;
        }

        public abstract void OpenUI();

    }
}