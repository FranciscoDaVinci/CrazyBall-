using UnityEngine;
using TMPro;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    //[SerializeField] TextMeshProUGUI console;
    [SerializeField] string gameIdAndroid = "5735185";
    //[SerializeField] string gameIdIOS = "5735184";

    public static string GameIdAndroid { get { return instance.gameIdAndroid; } }
    //public static string interstitialAndroid { get { return "Interstitial_Android"; } }
    public static string rewardedAndroid { get { return "Rewarded_Android"; } }
    //public static string bannerAndroid { get { return "Banner_Android"; } }

    public bool onTesting = true;

    [SerializeField] AddsRewarded rewarded;

    public static AdsManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        if(!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameIdAndroid, onTesting, this);
        }
    }

    public void ButtonRewarded()
    {
        //Debug.Log("El boton si funciona");
        rewarded.ShowRewarded();
        
    }

    void IUnityAdsInitializationListener.OnInitializationComplete()
    {
        rewarded.StartLoadRewarded();
        Debug.Log("Se inicializaron las Ads");
    }

    void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
    }
}