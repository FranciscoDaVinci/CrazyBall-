using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlMode
{
    Mobile = 0,
    Keyboard = 1
}

public class ControlManager : MonoBehaviour
{
    public static ControlManager Instance;

    [SerializeField] private GameObject joystickUI;

    public ControlMode CurrentMode { get; private set; }

    private const string ControlKey = "ControlMode";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadControlMode();
    }

    public void SetControlMode(ControlMode mode)
    {
        CurrentMode = mode;

        PlayerPrefs.SetInt(ControlKey, (int)mode);
        PlayerPrefs.Save();

        if (joystickUI != null)
        {
            joystickUI.SetActive(mode == ControlMode.Mobile);
        }

        Debug.Log("Modo de control seleccionado: " + mode);
    }

    private void LoadControlMode()
    {
        CurrentMode = (ControlMode)PlayerPrefs.GetInt(ControlKey, (int)ControlMode.Mobile);

        if (joystickUI != null)
        {
            joystickUI.SetActive(CurrentMode == ControlMode.Mobile);
        }

        Debug.Log("Modo de control cargado: " + CurrentMode);
    }

    public void SelectMobile()
    {
        SetControlMode(ControlMode.Mobile);
    }

    public void SelectKeyboard()
    {
        SetControlMode(ControlMode.Keyboard);
    }
}
