using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SaveManager : MonoBehaviour
{
    SaveData saveData;
    [SerializeField] SavePPrefs savePPrefs;
    [SerializeField] bool createDeleteButton = true;

    void Start()
    {
        saveData = new SaveData();

        if (createDeleteButton)
        {
            CreateDeleteDataButton();
        }
    }

    public void ButtonPlayerPrefSave()
    {
        savePPrefs.Save(saveData);
    }

    public void ButtonPlayerPrefLoad()
    {
        saveData = savePPrefs.Load();
    }

    public void ConfirmDeleteSaveData()
    {
        ConfirmationManager.Show(
            "¿Borrar todos los datos de juego? Esta accion no se puede deshacer.",
            DeleteSaveData);
    }

    public void DeleteSaveData()
    {
        savePPrefs.ClearAll();
        saveData = new SaveData();

        MaterialManager.SelectSkinsN = 0;
        MaterialManager.SelectSkinsS = 0;
        MaterialManager.SelectSkinsB = 0;
        ValueSkins.buyed = 0;
        AddsRewarded.Money = 0;

        var lifePlayer = FindObjectOfType<LifePlayer>();
        var maxLives = lifePlayer != null ? lifePlayer.maxLifeValue : 5;
        LifePlayer.Lifes = maxLives;
        LifePlayer.next = DateTime.Now;

        var matManager = FindObjectOfType<MaterialManager>();
        if (matManager != null)
        {
            matManager.SkinSelectorNormal(0);
            matManager.SkinSelectorSpike(0);
            matManager.SkinSelectorBounce(0);
        }

        var textValues = FindObjectOfType<TextValuesIU>();
        if (textValues != null)
        {
            textValues.SetValue();
            textValues.SetLife();
        }

        Debug.Log("Datos de juego borrados");

        SceneLoadManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void CreateDeleteDataButton()
    {
        var optionsPanel = FindGameObjectByName("Menu Options");
        if (optionsPanel == null || optionsPanel.transform.Find("DeleteData") != null)
        {
            return;
        }

        var buttonGO = new GameObject("DeleteData");
        buttonGO.transform.SetParent(optionsPanel.transform, false);

        var rect = buttonGO.AddComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0f);
        rect.anchorMax = new Vector2(0.5f, 0f);
        rect.pivot = new Vector2(0.5f, 0f);
        rect.anchoredPosition = new Vector2(0f, 60f);
        rect.sizeDelta = new Vector2(320f, 80f);

        var image = buttonGO.AddComponent<Image>();
        image.color = new Color(0.7f, 0.15f, 0.15f, 1f);

        var button = buttonGO.AddComponent<Button>();
        button.targetGraphic = image;
        button.onClick.AddListener(ConfirmDeleteSaveData);

        var textGO = new GameObject("Text");
        textGO.transform.SetParent(buttonGO.transform, false);

        var textRect = textGO.AddComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;

        var label = textGO.AddComponent<TextMeshProUGUI>();
        label.text = "Borrar datos";
        label.alignment = TextAlignmentOptions.Center;
        label.fontSize = 28f;
        label.color = Color.white;
    }

    static GameObject FindGameObjectByName(string objectName)
    {
        var transforms = Resources.FindObjectsOfTypeAll<Transform>();
        foreach (var t in transforms)
        {
            if (t.name == objectName && t.hideFlags == HideFlags.None && t.gameObject.scene.IsValid())
            {
                return t.gameObject;
            }
        }

        return null;
    }
}
