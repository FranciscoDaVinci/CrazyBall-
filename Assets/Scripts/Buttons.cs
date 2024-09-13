using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject PlayerNormal;
    [SerializeField] GameObject PlayerSpikes;
    [SerializeField] GameObject PlayerBounce;
    [SerializeField] int Estate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (Estate != 1)
            {
                Destroy(gameObject);
                Instantiate(PlayerNormal, transform.position, Quaternion.identity);
                _ = CameraControl.instance;
                Estate = 1;
            }

            else
            {
                Debug.Log("Ya esta en esta forma");
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {

            if (Estate != 2)
            {
                Destroy(gameObject);
                Instantiate(PlayerSpikes, transform.position, Quaternion.identity);
                _ = CameraControl.instance;
                Estate = 2;
            }

            else
            {
                Debug.Log("Ya esta en esta forma");
            }

        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (Estate != 3)
            {
                Destroy(gameObject);
                Instantiate(PlayerBounce, transform.position, Quaternion.identity);
                _ = CameraControl.instance;
                Estate = 3;
            }

            else
            {
                Debug.Log("Ya esta en esta forma");
            }

        }
    }
}
