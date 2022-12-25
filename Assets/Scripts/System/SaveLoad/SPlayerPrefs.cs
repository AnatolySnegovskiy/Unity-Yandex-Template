using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace System.SaveLoad
{
    public static class SPlayerPrefs
    {
        public static void SetString(string fieldName, string value)
        {
            PlayerPrefs.SetString(MD5(fieldName), Encrypt(value));
        }

        public static string GetString(string fieldName, string defaultValue = "")
        {
            return Decrypt(PlayerPrefs.GetString(MD5(fieldName)), defaultValue);
        }

        public static void SetInt(string fieldName, int value)
        {
            PlayerPrefs.SetString(MD5(fieldName), Encrypt(value.ToString()));
        }

        public static int GetInt(string fieldName, int defaultValue = 0)
        {
            return Decrypt(PlayerPrefs.GetString(MD5(fieldName)), defaultValue);
        }

        public static void SetFloat(string fieldName, float value)
        {
            PlayerPrefs.SetString(MD5(fieldName), Encrypt(value.ToString(CultureInfo.InvariantCulture)));
        }

        public static float GetFloat(string fieldName, float defaultValue = 0)
        {
            return Decrypt(PlayerPrefs.GetString(MD5(fieldName)), defaultValue);
        }

        public static bool HasKey(string fieldName)
        {
            return PlayerPrefs.HasKey(MD5(fieldName));
        }

        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public static void DeleteKey(string fieldName)
        {
            PlayerPrefs.DeleteKey(MD5(fieldName));
        }

        public static void Save()
        {
            PlayerPrefs.Save();
        }

        private const string SecretKey = "randowm";
        private static readonly byte[] Key = new byte[8] { 22, 41, 18, 40, 38, 217, 65, 64 };
        private static readonly byte[] Iv = new byte[8] { 34, 68, 46, 43, 50, 87, 2, 115 };

        private static string Encrypt(string s)
        {
            byte[] inputBuffer = Encoding.Unicode.GetBytes(s);
            byte[] outputBuffer = DES.Create().CreateEncryptor(Key, Iv)
                .TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

            return Convert.ToBase64String(outputBuffer);
        }

        private static T Decrypt<T>(string s, T defaultValue)
        {
            byte[] inputBuffer = Convert.FromBase64String(s);

            if (inputBuffer.Length == 0) {
                return defaultValue;
            }
            
            byte[] outputBuffer = DES.Create().CreateDecryptor(Key, Iv)
                .TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            return (T)(Convert.ChangeType(Encoding.Unicode.GetString(outputBuffer), typeof(T), CultureInfo.InvariantCulture) ?? defaultValue);
        }

        private static string MD5(string s)
        {
            byte[] hashBytes =
                new MD5CryptoServiceProvider().ComputeHash(
                    new UTF8Encoding().GetBytes(s + SecretKey + SystemInfo.deviceUniqueIdentifier)
                );

            string hashString =
                hashBytes.Aggregate(
                    "",
                    (current, t) => current + Convert.ToString(t, 16).PadLeft(2, '0')
                );

            return hashString.PadLeft(32, '0');
        }
    }
}
