using UnityEngine;

public class ValueSkins : MonoBehaviour
{
    public static int SelectSkinsN;
    public static int SelectSkinsS;
    public static int SelectSkinsB;

    [SerializeField] MaterialManager mManager;
    public int skinValue;
    public static int buyed;
    public GameObject Reward;
    public GameObject Obtained;
    public GameObject[] NotObtained;

    int _baseSkinValue;
    void Awake()
    {
        _baseSkinValue = skinValue;
    }
    void Start()
    {
        if (RemoteConfigManager.IsReady)
        {
            ApplyRemoteSettings(RemoteConfigManager.SkinPriceMultiplier);
        }
        else
        {
            RemoteConfigManager.ConfigApplied += OnRemoteConfigApplied;
        }
    }
    void OnDestroy()
    {
        RemoteConfigManager.ConfigApplied -= OnRemoteConfigApplied;
    }
    void OnRemoteConfigApplied()
    {
        if (RemoteConfigManager.IsReady)
        {
            ApplyRemoteSettings(RemoteConfigManager.SkinPriceMultiplier);
        }
    }
    public void ApplyRemoteSettings(float priceMultiplier)
    {
        if (buyed == 1 || _baseSkinValue <= 0)
        {
            return;
        }
        skinValue = Mathf.Max(1, Mathf.RoundToInt(_baseSkinValue * priceMultiplier));
    }

    public void SkinBounce(int value)
    {
        if (skinValue > AddsRewarded.Money)
        {
            Reward.SetActive(true);
            Debug.Log("No tiene el dinero suficiente como para comprar esta Skin");
            return;
        }

        ConfirmationManager.Show(
            "¿Comprar esta skin por " + skinValue + " monedas?",
            () => CompleteSkinBounce(value));
    }

    void CompleteSkinNormal(int value)
    {
        mManager.SkinSelectorNormal(value);
        AddsRewarded.Money -= skinValue;
        skinValue = 0;
        Obtained.SetActive(true);
        buyed = 1;
        Debug.Log("Esta comprado, vale " + buyed);
        for (int i = 0; i < NotObtained.Length; i++)
        {
            NotObtained[i].SetActive(false);
        }
    }

    void CompleteSkinSpike(int value)
    {
        mManager.SkinSelectorSpike(value);
        AddsRewarded.Money -= skinValue;
        skinValue = 0;
        Obtained.SetActive(true);
        buyed = 1;
        Debug.Log("La skin ahora vale" + skinValue);
        for (int i = 0; i < NotObtained.Length; i++)
        {
            NotObtained[i].SetActive(false);
        }
    }

    void CompleteSkinBounce(int value)
    {
        mManager.SkinSelectorBounce(value);
        AddsRewarded.Money -= skinValue;
        skinValue = 0;
        Obtained.SetActive(true);
        buyed = 1;
        Debug.Log("La skin ahora vale" + skinValue);
        for (int i = 0; i < NotObtained.Length; i++)
        {
            NotObtained[i].SetActive(false);
        }
    }
}