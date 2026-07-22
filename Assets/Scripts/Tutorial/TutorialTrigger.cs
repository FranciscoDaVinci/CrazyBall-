using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private string[] validTags;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró al trigger: " + other.name + " | Tag: " + other.tag);

        foreach (string tag in validTags)
        {
            if (other.CompareTag(tag))
            {
                Debug.Log("Tag válido: " + tag);
                TutorialManager.Instance?.CompleteFinish();
                return;
            }
        }
    }
}

