using System;
using UnityEngine;

public class BreakableGlass : MonoBehaviour
{
    [SerializeField] float breakDelay = 0.3f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball_Heavy"))
        {
            AudioController.PlaySFX(0);
            Invoke(nameof(Break), breakDelay);
        }
    }

    void Break()
    {
        Destroy(gameObject);
    }
}
