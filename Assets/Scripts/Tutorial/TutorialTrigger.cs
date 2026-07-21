using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball_Normal") ||other.CompareTag("Ball_Fast") || other.CompareTag("Ball_Heavy"))

            TutorialManager.Instance.FinishTutorial();
    }
}
