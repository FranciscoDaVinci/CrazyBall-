using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedInput : MonoBehaviour
{
    public bool ballSpike;
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.name != "SpikeState")
        {
            ballSpike = true;
        }
        else
        {
            ballSpike = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
            ballSpike = false;
        
    }
}
