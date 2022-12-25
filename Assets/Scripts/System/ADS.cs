using YandexGamesSDK.Scripts;

namespace System
{
    public class Ads
    {
        private static YandexSDK yandexSDK;
        private static bool adShow;
        private readonly Action showAd;
        private readonly Action hideAd;
        
        public Ads(Action showAd, Action hideAd)
        {
            this.showAd = showAd;
            this.hideAd = hideAd;
        }

        private void Init()
        {
            yandexSDK = YandexSDK.Instance;
            yandexSDK.onInterstitialShown += () => adShow = false;
            yandexSDK.onInterstitialFailed += (a) => adShow = false;
            
            yandexSDK.onInterstitialShown += hideAd;
            yandexSDK.onInterstitialFailed += (a) => hideAd.Invoke();
        }

        public void ShowFullScreen()
        {
            if (!yandexSDK) {
                Init();
            }

            if (adShow) return;

            showAd.Invoke();
            adShow = true;
            yandexSDK.ShowInterstitial();
        }
    }
}
