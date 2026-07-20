using System;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.RemoteConfig;

public class RemoteConfigManager : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    public static RemoteConfigManager Instance { get; private set; }
    public static bool IsReady { get; private set; }
    public static event Action ConfigApplied;

    public static float PlayerMoveSpeed { get; private set; } = 4f;
    public static float PlayerJumpForce { get; private set; } = 1200f;
    public static float PlayerGravity { get; private set; } = 5f;
    public static float EnemyPressSpeed { get; private set; } = 1f;
    public static float EnemySmashDelay { get; private set; } = 0.5f;
    public static int MaxLives { get; private set; } = 10;
    public static float SkinPriceMultiplier { get; private set; } = 1f;

    const string KeyPlayerMoveSpeed = "player_move_speed";
    const string KeyPlayerJumpForce = "player_jump_force";
    const string KeyPlayerGravity = "player_gravity";
    const string KeyEnemyPressSpeed = "enemy_press_speed";
    const string KeyEnemySmashDelay = "enemy_smash_delay";
    const string KeyMaxLives = "max_lives";
    const string KeySkinPriceMultiplier = "skin_price_multiplier";

    [SerializeField] bool fetchOnStart = true;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void AutoCreate()
    {
        if (Instance != null)
        {
            return;
        }

        var existing = FindObjectOfType<RemoteConfigManager>();
        if (existing == null)
        {
            var go = new GameObject("RemoteConfigManager");
            go.AddComponent<RemoteConfigManager>();
        }
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    async void Start()
    {
        if (!fetchOnStart)
        {
            return;
        }

        await FetchRemoteConfigAsync();
    }

    public async Task FetchRemoteConfigAsync()
    {
        try
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }

            RemoteConfigService.Instance.FetchCompleted -= OnFetchCompleted;
            RemoteConfigService.Instance.FetchCompleted += OnFetchCompleted;
            await RemoteConfigService.Instance.FetchConfigsAsync(new userAttributes(), new appAttributes());
        }
        catch (Exception exception)
        {
            Debug.LogWarning("Remote Config no disponible, se usan valores locales: " + exception.Message);
            IsReady = false;
        }
    }

    void OnFetchCompleted(ConfigResponse response)
    {
        if (response.status == ConfigRequestStatus.Success)
        {
            ReadRemoteValues();
            IsReady = true;
            Debug.Log("Remote Config cargado correctamente");
        }
        else
        {
            IsReady = false;
            Debug.LogWarning("Remote Config fallo: " + response.status);
        }

        ApplyToGameplay();
        ConfigApplied?.Invoke();
    }

    void ReadRemoteValues()
    {
        var config = RemoteConfigService.Instance.appConfig;

        PlayerMoveSpeed = config.GetFloat(KeyPlayerMoveSpeed, PlayerMoveSpeed);
        PlayerJumpForce = config.GetFloat(KeyPlayerJumpForce, PlayerJumpForce);
        PlayerGravity = config.GetFloat(KeyPlayerGravity, PlayerGravity);
        EnemyPressSpeed = config.GetFloat(KeyEnemyPressSpeed, EnemyPressSpeed);
        EnemySmashDelay = config.GetFloat(KeyEnemySmashDelay, EnemySmashDelay);
        MaxLives = config.GetInt(KeyMaxLives, MaxLives);
        SkinPriceMultiplier = config.GetFloat(KeySkinPriceMultiplier, SkinPriceMultiplier);
    }

    void ApplyToGameplay()
    {
        if (!IsReady)
        {
            return;
        }

        var players = FindObjectsOfType<MovPlayer>(true);
        foreach (var player in players)
        {
            player.ApplyRemoteSettings(PlayerMoveSpeed, PlayerJumpForce, PlayerGravity);
        }

        var lifePlayers = FindObjectsOfType<LifePlayer>(true);
        foreach (var lifePlayer in lifePlayers)
        {
            lifePlayer.ApplyRemoteSettings(MaxLives);
        }

        var skins = FindObjectsOfType<ValueSkins>(true);
        foreach (var skin in skins)
        {
            skin.ApplyRemoteSettings(SkinPriceMultiplier);
        }

        var respawns = FindObjectsOfType<GameRespawn>(true);
        foreach (var respawn in respawns)
        {
            respawn.ApplyRemoteSettings(EnemySmashDelay);
        }

        ApplyPressMachineSettings();
    }

    void ApplyPressMachineSettings()
    {
        var smashZones = GameObject.FindGameObjectsWithTag("Smash");
        foreach (var smashZone in smashZones)
        {
            var animator = smashZone.GetComponentInParent<Animator>();
            if (animator != null)
            {
                animator.speed = EnemyPressSpeed;
            }
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            RemoteConfigService.Instance.FetchCompleted -= OnFetchCompleted;
            Instance = null;
        }
    }
}

