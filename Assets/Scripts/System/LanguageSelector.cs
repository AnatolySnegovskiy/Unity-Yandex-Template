using UnityEngine;
using YandexGamesSDK.Scripts;

namespace System
{
    public class LanguageSelector : MonoBehaviour
    {
        [SerializeField] private GameObject main;
        [SerializeField] private GameObject mainRu;

        [SerializeField] private GameObject gui;
        [SerializeField] private GameObject guiRu;
        
        private void Start()
        {
            YandexSDK.Instance.onLanguageSelected += SelectOnLanguage;
#if UNITY_EDITOR
            YandexSDK.Instance.OnLanguageSelected("en");
#else
        YandexSDK.instance.StartYandex();
#endif
        }

        private void SelectOnLanguage(string lang)
        {
            if (lang == "ru") {
                mainRu.SetActive(true);
                guiRu.SetActive(true);
            } else {
                main.SetActive(true);
                gui.SetActive(true);
            }
        }
    }
}
