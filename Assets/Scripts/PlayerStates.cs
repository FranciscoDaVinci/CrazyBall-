using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour, IObserverPlayerState
{
    int _ballPosition;
    [SerializeField] GameObject[] balls;
    [SerializeField] Transform transBallPosition;
    public IObservablePlayerState _obs;

    public void Awake()
    {
        _obs = GetComponent<IObservablePlayerState>();
        if (_obs != null)
        {
            _obs.Suscribe(this);
            //Debug.Log("Se suscribio");
        }
    }

    private void Start()
    {
        transBallPosition.position = balls[0].transform.position;
    }

    void Update()
    {
        //Mueve el GameObject que tiene el Transofrm a la pelotita que esta prendida
        //No se puede sacar del Update porque la camara sigue el "transBallPosition" para evitar saltos de camara.
        BallPosition();
    }

    void BallPosition()
    {

        for (int i = 0; i < balls.Length; i++)
        {
            if (_ballPosition == i)
            {
                transBallPosition.position = balls[i].transform.position;
            }
        }
    }

    public void States()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            if (i == _ballPosition)
            {
                balls[i].SetActive(true);
                balls[i].transform.position = transBallPosition.position;
            }
            else
            {
                balls[i].SetActive(false);
            }
        }

    }

    public void ChangeState(int states)
    {
        for (int i = 0; i < balls.Length; i++)
        {
            if (states == i)
            {
                _ballPosition = i;                
                Debug.Log(_ballPosition + " Posicion de la bola");
                States();
            }
        }
    }
}
