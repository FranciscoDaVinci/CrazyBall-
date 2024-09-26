using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour, IObserverPlayerState   
{
    int _ballPosition;
    [SerializeField] GameObject PlayerNormal;
    [SerializeField] GameObject PlayerSpikes;
    [SerializeField] GameObject PlayerBounce;
    [SerializeField] Transform transBallPosition;
    public IObservablePlayerState _obs;

    public void Awake()
    {
        _obs = GetComponent<IObservablePlayerState>();
        if (_obs != null)
        {
            _obs.Suscribe(this);
            Debug.Log("Se suscribio");
        }
    }

    private void Start()
    {
        transBallPosition.position = PlayerNormal.transform.position;
    }

    void Update()
    {
        //Mueve el GameObject que tiene el Transofrm a la pelotita que esta prendida  
        BallPosition();

    }

    void BallPosition()
    {
        if (_ballPosition == 0)
        {
            transBallPosition.position = PlayerNormal.transform.position;
        }

        else if (_ballPosition == 1)
        {
            transBallPosition.position = PlayerSpikes.transform.position;
        }

        else if (_ballPosition == 2)
        {
            transBallPosition.position = PlayerBounce.transform.position;
        }
    }

    public void NormalState()
    {
        if (_ballPosition != 0)
        {
            PlayerSpikes.SetActive(false);
            PlayerBounce.SetActive(false);

            PlayerNormal.SetActive(true);

            PlayerNormal.transform.position = transBallPosition.position;
        }

        else
        {
            Debug.Log("Ya esta en esta forma");
        }
    }

    public void SpikeState()
    {
        if (_ballPosition != 1)
        {
            PlayerNormal.SetActive(false);
            PlayerBounce.SetActive(false);

            PlayerSpikes.SetActive(true);

            PlayerSpikes.transform.position = transBallPosition.position;
        }

        else
        {
            Debug.Log("Ya esta en esta forma");
        }
    }

    public void BounceState()
    {
        if (_ballPosition != 2)
        {
            PlayerNormal.SetActive(false);
            PlayerSpikes.SetActive(false);

            PlayerBounce.SetActive(true);

            PlayerBounce.transform.position = transBallPosition.position;
        }

        else
        {
            Debug.Log("Ya esta en esta forma");
        }
    }

    public void ChangeState(int states)
    {
        if (states == 0)
        {
            NormalState();
            _ballPosition = states;
        }

        else if (states == 1)
        {
            SpikeState();
            _ballPosition = states;
        }

        else if (states == 2)
        {
            BounceState();
            _ballPosition = states;
        }
    }

    
}
