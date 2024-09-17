using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [SerializeField] int _estate;
    [SerializeField] GameObject PlayerNormal;
    [SerializeField] GameObject PlayerSpikes;
    [SerializeField] GameObject PlayerBounce;
    [SerializeField] Transform ballPosition;

    private void Start()
    {
        ballPosition.position = PlayerNormal.transform.position;
    }

    void Update()
    {
        //Mueve el GameObject que tiene el Transofrm a la pelotita que esta prendida  
        if (_estate == 1)
        {
            ballPosition.position = PlayerNormal.transform.position;
        }

        else if (_estate == 2)
        {
            ballPosition.position = PlayerSpikes.transform.position;
        }

        else
        {
            ballPosition.position = PlayerBounce.transform.position;
        }

    }

    public void NormalState()
    {
        if (_estate != 1)
        {
            PlayerSpikes.SetActive(false);
            PlayerBounce.SetActive(false);

            PlayerNormal.SetActive(true);

            PlayerNormal.transform.position = ballPosition.position;

            _estate = 1;
        }

        else
        {
            Debug.Log("Ya esta en esta forma");
        }
    }

    public void SpikeState()
    {
        if (_estate != 2)
        {
            PlayerNormal.SetActive(false);
            PlayerBounce.SetActive(false);

            PlayerSpikes.SetActive(true);

            PlayerSpikes.transform.position = ballPosition.position;
            _estate = 2;
        }

        else
        {
            Debug.Log("Ya esta en esta forma");
        }
    }

    public void BounceState()
    {
        if (_estate != 3)
        {
            PlayerNormal.SetActive(false);
            PlayerSpikes.SetActive(false);

            PlayerBounce.SetActive(true);

            PlayerBounce.transform.position = ballPosition.position;

            _estate = 3;
        }

        else
        {
            Debug.Log("Ya esta en esta forma");
        }
    }
}
