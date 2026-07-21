using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    public static string rewardedAndroid { get { return "Rewarded_Android"; } }
    public static string interstitialAndroid { get { return "Interstitial_Android"; } }
    public static string bannerAndroid { get { return "Banner_Android"; } }

    [SerializeField] string gameIdAndroid = "5735185";

    public bool onTesting = true;

    [SerializeField] AddsRewarded rewarded;

    [SerializeField] AddsBanner banner;
    [SerializeField] AddsInterstitial interstitial;

    public static AdsManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            EnsureAdComponents();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void EnsureAdComponents()
    {
            if (rewarded == null)
            {
                rewarded = GetComponent<AddsRewarded>();
            }
        if (banner == null)
        {
            banner = GetComponent<AddsBanner>();
            if (banner == null)
            {
                banner = gameObject.AddComponent<AddsBanner>();
            }
        }
        if (interstitial == null)
        {
            interstitial = GetComponent<AddsInterstitial>();
            if (interstitial == null)
            {
                interstitial = gameObject.AddComponent<AddsInterstitial>();
            }
        }
    }
    void Start()
    {
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameIdAndroid, onTesting, this);
        }
        else if (Advertisement.isInitialized)
        {
            OnAdsReady();
        }
    }
    public void ButtonRewarded()
    {
        rewarded.ShowRewarded();
    }
    public static void ShowDeathInterstitial()
    {
        if (instance != null && instance.interstitial != null)
        {
            instance.interstitial.ShowInterstitial();
        }
    }
    // TP Final - interstitial al volver al menu
    public static void ShowMenuInterstitial(Action onComplete)
    {
        if (instance != null && instance.interstitial != null)
        {
            instance.interstitial.ShowInterstitial(onComplete);
        }
        else
        {
            onComplete?.Invoke();
        }
    }
    public void UpdateBannerForScene(string sceneName)
    {
        if (banner == null)
        {
            return;
        }
        if (sceneName == "MainMenu" || sceneName == "LevelSelector")
        {
            banner.ShowBanner();
        }
        else
        {
            banner.HideBanner();
        }
    }
    void UpdateBannerForCurrentScene()
    {
        UpdateBannerForScene(SceneManager.GetActiveScene().name);
    }
    void OnAdsReady()
    {
        rewarded.StartLoadRewarded();
        interstitial.StartLoadInterstitial();
        UpdateBannerForCurrentScene();
        Debug.Log("Ads inicializadas: Rewarded (Parcial 2), Banner e Interstitial (Final)");
    }
    void IUnityAdsInitializationListener.OnInitializationComplete()
    {
        OnAdsReady();
    }
    void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Ads init error: " + message);
    }
}