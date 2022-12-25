using Models;
using UnityEngine;

namespace System.SaveLoad
{
    public class SaveLoad
    {
        private const string Key = "KhhhreyKe1y222114a22s1222d1we55t345AjjSFWRWQ1";
        private static SaveLoad instance;

        private SaveLoad()
        {
        }

        public static SaveLoad Instance
        {
            get
            {
                return instance ??= new SaveLoad();
            }
        }

        public void Save<T>(T data)
        {
            SPlayerPrefs.SetString(Key, JsonUtility.ToJson(data));
            SPlayerPrefs.Save();
        }

        public void Load<T>(T data)
        {
            string localSave = SPlayerPrefs.GetString(Key);

            if (!string.IsNullOrEmpty(localSave))
            {
                JsonUtility.FromJsonOverwrite(localSave, data);
            }
        }
    }
}