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

    private bool waitingMove = false;

    private bool changingStep = false;

    private void Awake()
    {
        Instance = this;
    }

    public bool CanUseJoystick()
    {
        return currentStep == 0 || currentStep == 4;
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
                StartCoroutine(HideTutorialAfterDelay());
                break;

            default:
                break;
        }
    }

    public void CompleteMove()
    {
        if (currentStep != 0 || waitingMove)
            return;

        waitingMove = true;
        StartCoroutine(CompleteMoveDelay());
    }

    public void CompleteJump()
    {
        if (currentStep != 2)
            return;

        if (!bounceSelected)
            return;

        bounceSelected = false;

        NextStep();

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

        NextStep();

    }

    public void CompleteState()
    {
        if (currentStep == 2)
        {
            NextStep();

        }
    }

    public void CompleteDash()
    {
        if (currentStep != 1)
            return;

        NextStep();

    }

    public void CompleteFinish()
    {
        if (currentStep != 4)
            return;

        Debug.Log("Tutorial terminado");
    }

    public int GetCurrentStep()
    {
        return currentStep;
    }

    private void NextStep()
    {
        if (changingStep)
            return;

        changingStep = true;

        currentStep++;
        ShowCurrentStep();

        changingStep = false;
    }

    private IEnumerator HideTutorialAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        tutorialPanel.SetActive(false);
    }

    private IEnumerator CompleteMoveDelay()
    {
        yield return new WaitForSeconds(3f);

        waitingMove = false;
        NextStep();
    }

    public bool CanUseDash()
    {
        return currentStep >= 1;
    }

    public bool CanChangeBall()
    {
        return currentStep >= 2;
    }

    public bool CanJump()
    {
        return currentStep >= 2 && bounceSelected;
    }

    public bool CanUseSpike()
    {
        return currentStep >= 3;
    }

}
