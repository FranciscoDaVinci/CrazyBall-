using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject youwinText;

    private void Start()
    {
        youwinText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            youwinText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
