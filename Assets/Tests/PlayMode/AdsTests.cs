using System;
using NUnit.Framework;
using UnityEngine;
using YandexGamesSDK.Scripts;

namespace Tests.PlayMode
{
    public class AdsTests
    {
        private int testItem;
        
        [Test]
        public void AdsTestsSimplePasses()
        {
            GameObject go = new GameObject();
            go.AddComponent<YandexSDK>();
        
            Ads ads = new Ads(ShowAd, HideAd);
            ads.ShowFullScreen();
            Assert.AreEqual(2, testItem);
        }

        private void ShowAd()
        {
            testItem++;
        }

        private void HideAd()
        {
            testItem++;
        }
    }
}
