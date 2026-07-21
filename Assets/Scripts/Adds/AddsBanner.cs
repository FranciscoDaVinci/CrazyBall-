using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsBanner : MonoBehaviour
{
    bool _isLoaded;
    bool _isVisible;
    public void ShowBanner()
    {
        if (!Advertisement.isInitialized)
        {
            return;
        }
        if (_isLoaded && _isVisible)
        {
            return;
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Load(AdsManager.bannerAndroid, new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        });
    }
    public void HideBanner()
    {
        if (!Advertisement.isInitialized)
        {
            return;
        }
        Advertisement.Banner.Hide(true);
        _isVisible = false;
    }
    void OnBannerLoaded()
    {
        _isLoaded = true;
        Advertisement.Banner.Show(AdsManager.bannerAndroid);
        _isVisible = true;
    }
    void OnBannerError(string message)
    {
        Debug.Log("Banner error: " + message);
        _isLoaded = false;
        _isVisible = false;
    }
}
