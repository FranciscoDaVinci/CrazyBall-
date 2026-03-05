using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioClip[] _sfxClips;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _sfxSource = GetComponent<AudioSource>();

        if (!_sfxSource)
        {
            Debug.LogError("Faltan AudioSources asignados");
        }
    }

    public static void PlaySFX(int index)
    {
        if (Instance == null) return;

        if (index < 0 || index >= Instance._sfxClips.Length) return;
        Instance._sfxSource.PlayOneShot(Instance._sfxClips[index]);
    }

    public static void PauseSFX()
    {
        if (Instance == null) return;
        Instance._sfxSource.Pause();
    }

    public static void ResumeSFX()
    {
        if (Instance == null) return;
        Instance._sfxSource.UnPause();
    }
}
