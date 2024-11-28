using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedInput2 : MonoBehaviour
{
    public bool ballBounce = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.name != "PlayerBounce")
        {
            ballBounce = true;
        }
        else
        {
            ballBounce = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        ballBounce = false;

    }
}
