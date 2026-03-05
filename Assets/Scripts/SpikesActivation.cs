using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesActivation : MonoBehaviour
{
     public Animator anim;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            anim.SetTrigger("Activate");
        }
    }
}
