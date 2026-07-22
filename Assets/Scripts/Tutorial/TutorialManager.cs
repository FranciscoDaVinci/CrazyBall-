using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    [Header("UI")]
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] TMP_Text tutorialText;

    [Header("Mensajes")]
    [TextArea] public string moveMessage;
    [TextArea] public string jumpMessage;
    [TextArea] public string stateMessage;
    [TextArea] public string dashMessage;
    [TextArea] public string finishMessage;

    private int currentStep = 0;

    private bool bounceSelected = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ShowCurrentStep();
    }

    void ShowCurrentStep()
    {
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
                break;
        }
    }

    public void CompleteMove()
    {
        if (currentStep != 0)
            return;

        currentStep++;
        ShowCurrentStep();
    }

    public void CompleteJump()
    {
        if (currentStep != 2)
            return;

        if (!bounceSelected)
            return;

        bounceSelected = false;

        currentStep++;
        ShowCurrentStep();
    }

    public void CompleteBounce()
    {
        if (currentStep != 2)
            return;

        bounceSelected = true;
    }

    public void CompleteSpike()
    {
        if (currentStep != 3)
            return;

        currentStep++;
        ShowCurrentStep();
    }

    public void CompleteState()
    {
        if (currentStep == 2)
        {
            currentStep++;
            ShowCurrentStep();
        }
    }

    public void CompleteDash()
    {
        if (currentStep != 1)
            return;

        currentStep++;
        ShowCurrentStep();
    }

    public void CompleteFinish()
    {
        Debug.Log("Tutorial terminado");

        if (currentStep != 4)
            return;

        StartCoroutine(HideTutorialAfterDelay());
    }

    public int GetCurrentStep()
    {
        return currentStep;
    }

    private IEnumerator HideTutorialAfterDelay()
    {
        Debug.Log("Esperando 2 segundos...");

        yield return new WaitForSeconds(2f);

        Debug.Log("Ocultando panel");

        tutorialPanel.SetActive(false);
    }
}
