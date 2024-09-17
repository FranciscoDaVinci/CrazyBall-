using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
     [SerializeField] PlayerStates state;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            state.NormalState();
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {

            state.SpikeState();
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            state.BounceState();
        }
    }
}
