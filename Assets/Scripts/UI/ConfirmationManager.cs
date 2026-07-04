using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationManager : MonoBehaviour
{
    static ConfirmationManager _instance;

    Canvas _canvas;
    TMP_Text _messageText;
    Action _onConfirm;
    Action _onCancel;

    public static void Show(string message, Action onConfirm, Action onCancel = null)
    {
        EnsureInstance();
        _instance.Open(message, onConfirm, onCancel);
    }

    static void EnsureInstance()
    {
        if (_instance != null)
        {
            return;
        }

        var go = new GameObject("ConfirmationManager");
        _instance = go.AddComponent<ConfirmationManager>();
        DontDestroyOnLoad(go);
        _instance.CreateUI();
    }

    void CreateUI()
    {
        _canvas = new GameObject("ConfirmationCanvas").AddComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        _canvas.sortingOrder = 1000;
        _canvas.gameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _canvas.gameObject.AddComponent<GraphicRaycaster>();
        DontDestroyOnLoad(_canvas.gameObject);

        var background = CreateImage("Background", _canvas.transform, new Color(0f, 0f, 0f, 0.7f));
        StretchFullScreen(background.GetComponent<RectTransform>());

        var panel = new GameObject("Panel");
        panel.transform.SetParent(_canvas.transform, false);
        var panelRect = panel.AddComponent<RectTransform>();
        panelRect.anchorMin = new Vector2(0.5f, 0.5f);
        panelRect.anchorMax = new Vector2(0.5f, 0.5f);
        panelRect.sizeDelta = new Vector2(520f, 220f);

        var panelImage = panel.AddComponent<Image>();
        panelImage.color = new Color(0.12f, 0.12f, 0.12f, 0.95f);

        _messageText = CreateText("Message", panel.transform, "", 24f);
        var messageRect = _messageText.GetComponent<RectTransform>();
        messageRect.anchorMin = new Vector2(0.05f, 0.45f);
        messageRect.anchorMax = new Vector2(0.95f, 0.95f);
        messageRect.offsetMin = Vector2.zero;
        messageRect.offsetMax = Vector2.zero;

        var yesButton = CreateButton("SiButton", panel.transform, "Si", new Color(0.15f, 0.65f, 0.25f, 1f), Confirm);
        var yesRect = yesButton.GetComponent<RectTransform>();
        yesRect.anchorMin = new Vector2(0.1f, 0.08f);
        yesRect.anchorMax = new Vector2(0.45f, 0.32f);
        yesRect.offsetMin = Vector2.zero;
        yesRect.offsetMax = Vector2.zero;

        var noButton = CreateButton("NoButton", panel.transform, "No", new Color(0.75f, 0.2f, 0.2f, 1f), Cancel);
        var noRect = noButton.GetComponent<RectTransform>();
        noRect.anchorMin = new Vector2(0.55f, 0.08f);
        noRect.anchorMax = new Vector2(0.9f, 0.32f);
        noRect.offsetMin = Vector2.zero;
        noRect.offsetMax = Vector2.zero;

        _canvas.gameObject.SetActive(false);
    }

    void Open(string message, Action onConfirm, Action onCancel)
    {
        _messageText.text = message;
        _onConfirm = onConfirm;
        _onCancel = onCancel;
        _canvas.gameObject.SetActive(true);
    }

    void Confirm()
    {
        _canvas.gameObject.SetActive(false);
        _onConfirm?.Invoke();
        ClearCallbacks();
    }

    void Cancel()
    {
        _canvas.gameObject.SetActive(false);
        _onCancel?.Invoke();
        ClearCallbacks();
    }

    void ClearCallbacks()
    {
        _onConfirm = null;
        _onCancel = null;
    }

    static GameObject CreateImage(string name, Transform parent, Color color)
    {
        var imageGO = new GameObject(name);
        imageGO.transform.SetParent(parent, false);
        var image = imageGO.AddComponent<Image>();
        image.color = color;
        return imageGO;
    }

    static TMP_Text CreateText(string name, Transform parent, string text, float fontSize)
    {
        var textGO = new GameObject(name);
        textGO.transform.SetParent(parent, false);
        var tmp = textGO.AddComponent<TextMeshProUGUI>();
        tmp.text = text;
        tmp.fontSize = fontSize;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.color = Color.white;
        return tmp;
    }

    static Button CreateButton(string name, Transform parent, string label, Color color, UnityEngine.Events.UnityAction action)
    {
        var buttonGO = new GameObject(name);
        buttonGO.transform.SetParent(parent, false);

        var image = buttonGO.AddComponent<Image>();
        image.color = color;

        var button = buttonGO.AddComponent<Button>();
        button.targetGraphic = image;
        button.onClick.AddListener(action);

        var text = CreateText("Text", buttonGO.transform, label, 22f);
        StretchFullScreen(text.GetComponent<RectTransform>());

        return button;
    }

    static void StretchFullScreen(RectTransform rect)
    {
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }
}