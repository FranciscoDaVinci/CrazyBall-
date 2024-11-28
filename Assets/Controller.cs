using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public ParedInput paredScript;
    public ParedInput2 paredScript2;
    public View viewScript;
    // Update is called once per frame
    void Update()
    {
     if(paredScript.ballSpike)
        {
            viewScript.cartelSpike.SetActive(true);
        }
    else
        {
            viewScript.cartelSpike.SetActive(false);
        } 
    if(paredScript2.ballBounce)
        {
            viewScript.cartelJump.SetActive(true);
        }
    else
        {
            viewScript.cartelJump.SetActive(false);
        }
    }
}
