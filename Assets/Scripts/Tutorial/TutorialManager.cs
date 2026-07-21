using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private TextMeshProUGUI tutorialText;

    [Header("Mensajes")]
    [TextArea]
    [SerializeField] private string moveMessage = "Usa WASD para moverte.";

    [TextArea]
    [SerializeField] private string jumpMessage = "Presiona ESPACIO para saltar.";

    [TextArea]
    [SerializeField] private string stateMessage = "Cambia el estado de la pelota.";

    [TextArea]
    [SerializeField] private string dashMessage = "Realiza un Dash.";

    [TextArea]
    [SerializeField] private string finishMessage = "¡Tutorial completado! Llega a la meta.";

    private int currentStep;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        currentStep = 0;
        ShowCurrentStep();
    }

    void ShowCurrentStep()
    {
        tutorialPanel.SetActive(true);

        switch (currentStep)
        {
            case 0:
                tutorialText.text = moveMessage;
                break;

            case 1:
                tutorialText.text = jumpMessage;
                break;

            case 2:
                tutorialText.text = stateMessage;
                break;

            case 3:
                tutorialText.text = dashMessage;
                break;

            case 4:
                tutorialText.text = finishMessage;
                break;

            default:
                tutorialPanel.SetActive(false);
                break;
        }
    }

    void NextStep()
    {
        currentStep++;
        ShowCurrentStep();
    }

    public void PlayerMoved()
    {
        if (currentStep == 0)
            NextStep();
    }

    public void PlayerJumped()
    {
        if (currentStep == 1)
            NextStep();
    }

    public void PlayerChangedState()
    {
        if (currentStep == 2)
            NextStep();
    }

    public void PlayerDashed()
    {
        if (currentStep == 3)
            NextStep();
    }

    public void FinishTutorial()
    {
        if (currentStep == 4)
            NextStep();
    }
}
