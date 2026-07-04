using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    static SceneLoadManager _instance;

    Canvas _canvas;
    Slider _progressBar;
    TMP_Text _progressText;
    bool _isLoading;

    public static void LoadScene(string sceneName)
    {
        EnsureInstance();
        _instance.StartLoad(sceneName);
    }

    public static void LoadScene(int buildIndex)
    {
        EnsureInstance();
        _instance.StartLoad(buildIndex);
    }

    static void EnsureInstance()
    {
        if (_instance != null)
        {
            return;
        }

        var go = new GameObject("SceneLoadManager");
        _instance = go.AddComponent<SceneLoadManager>();
        DontDestroyOnLoad(go);
        _instance.CreateLoadingUI();
    }

    void CreateLoadingUI()
    {
        _canvas = new GameObject("LoadingCanvas").AddComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        _canvas.sortingOrder = 999;
        _canvas.gameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _canvas.gameObject.AddComponent<GraphicRaycaster>();
        DontDestroyOnLoad(_canvas.gameObject);

        var background = new GameObject("Background").AddComponent<Image>();
        background.transform.SetParent(_canvas.transform, false);
        background.color = new Color(0f, 0f, 0f, 0.85f);
        var backgroundRect = background.GetComponent<RectTransform>();
        backgroundRect.anchorMin = Vector2.zero;
        backgroundRect.anchorMax = Vector2.one;
        backgroundRect.offsetMin = Vector2.zero;
        backgroundRect.offsetMax = Vector2.zero;

        var panel = new GameObject("LoadingPanel");
        panel.transform.SetParent(_canvas.transform, false);
        var panelRect = panel.AddComponent<RectTransform>();
        panelRect.anchorMin = new Vector2(0.5f, 0.5f);
        panelRect.anchorMax = new Vector2(0.5f, 0.5f);
        panelRect.sizeDelta = new Vector2(500f, 120f);

        var label = new GameObject("LoadingLabel").AddComponent<TextMeshProUGUI>();
        label.transform.SetParent(panel.transform, false);
        label.text = "Cargando...";
        label.fontSize = 28f;
        label.alignment = TextAlignmentOptions.Center;
        label.color = Color.white;
        var labelRect = label.GetComponent<RectTransform>();
        labelRect.anchorMin = new Vector2(0f, 0.55f);
        labelRect.anchorMax = new Vector2(1f, 1f);
        labelRect.offsetMin = Vector2.zero;
        labelRect.offsetMax = Vector2.zero;

        _progressText = new GameObject("ProgressText").AddComponent<TextMeshProUGUI>();
        _progressText.transform.SetParent(panel.transform, false);
        _progressText.text = "0%";
        _progressText.fontSize = 24f;
        _progressText.alignment = TextAlignmentOptions.Center;
        _progressText.color = Color.white;
        var progressTextRect = _progressText.GetComponent<RectTransform>();
        progressTextRect.anchorMin = new Vector2(0f, 0.35f);
        progressTextRect.anchorMax = new Vector2(1f, 0.55f);
        progressTextRect.offsetMin = Vector2.zero;
        progressTextRect.offsetMax = Vector2.zero;

        var sliderGO = new GameObject("ProgressBar");
        sliderGO.transform.SetParent(panel.transform, false);
        var sliderRect = sliderGO.AddComponent<RectTransform>();
        sliderRect.anchorMin = new Vector2(0f, 0f);
        sliderRect.anchorMax = new Vector2(1f, 0.3f);
        sliderRect.offsetMin = Vector2.zero;
        sliderRect.offsetMax = Vector2.zero;

        var sliderBackground = new GameObject("Background").AddComponent<Image>();
        sliderBackground.transform.SetParent(sliderGO.transform, false);
        sliderBackground.color = new Color(1f, 1f, 1f, 0.2f);
        var sliderBackgroundRect = sliderBackground.GetComponent<RectTransform>();
        sliderBackgroundRect.anchorMin = Vector2.zero;
        sliderBackgroundRect.anchorMax = Vector2.one;
        sliderBackgroundRect.offsetMin = Vector2.zero;
        sliderBackgroundRect.offsetMax = Vector2.zero;

        var fillArea = new GameObject("Fill Area");
        fillArea.transform.SetParent(sliderGO.transform, false);
        var fillAreaRect = fillArea.AddComponent<RectTransform>();
        fillAreaRect.anchorMin = Vector2.zero;
        fillAreaRect.anchorMax = Vector2.one;
        fillAreaRect.offsetMin = new Vector2(8f, 8f);
        fillAreaRect.offsetMax = new Vector2(-8f, -8f);

        var fill = new GameObject("Fill").AddComponent<Image>();
        fill.transform.SetParent(fillArea.transform, false);
        fill.color = new Color(0.2f, 0.75f, 1f, 1f);
        var fillRect = fill.GetComponent<RectTransform>();
        fillRect.anchorMin = Vector2.zero;
        fillRect.anchorMax = Vector2.one;
        fillRect.offsetMin = Vector2.zero;
        fillRect.offsetMax = Vector2.zero;

        _progressBar = sliderGO.AddComponent<Slider>();
        _progressBar.fillRect = fillRect;
        _progressBar.targetGraphic = fill;
        _progressBar.minValue = 0f;
        _progressBar.maxValue = 1f;
        _progressBar.value = 0f;
        _progressBar.interactable = false;

        _canvas.gameObject.SetActive(false);
    }

    void StartLoad(string sceneName)
    {
        if (_isLoading)
        {
            return;
        }

        Time.timeScale = 1f;
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    void StartLoad(int buildIndex)
    {
        if (_isLoading)
        {
            return;
        }

        Time.timeScale = 1f;
        StartCoroutine(LoadSceneRoutine(buildIndex));
    }

    IEnumerator LoadSceneRoutine(string sceneName)
    {
        _isLoading = true;
        ShowLoadingUI(0f);

        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            UpdateLoadingUI(asyncLoad.progress / 0.9f);
            yield return null;
        }

        UpdateLoadingUI(1f);
        yield return null;

        asyncLoad.allowSceneActivation = true;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        HideLoadingUI();
        _isLoading = false;
    }

    IEnumerator LoadSceneRoutine(int buildIndex)
    {
        _isLoading = true;
        ShowLoadingUI(0f);

        var asyncLoad = SceneManager.LoadSceneAsync(buildIndex);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            UpdateLoadingUI(asyncLoad.progress / 0.9f);
            yield return null;
        }

        UpdateLoadingUI(1f);
        yield return null;

        asyncLoad.allowSceneActivation = true;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        HideLoadingUI();
        _isLoading = false;
    }

    void ShowLoadingUI(float progress)
    {
        _canvas.gameObject.SetActive(true);
        UpdateLoadingUI(progress);
    }

    void HideLoadingUI()
    {
        _canvas.gameObject.SetActive(false);
    }

    void UpdateLoadingUI(float progress)
    {
        var clampedProgress = Mathf.Clamp01(progress);
        _progressBar.value = clampedProgress;
        _progressText.text = Mathf.RoundToInt(clampedProgress * 100f) + "%";
    }
}

