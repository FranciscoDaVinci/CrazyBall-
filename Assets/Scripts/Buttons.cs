using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour, IObservablePlayerState, IObservableButtons
{
    List<IObserverPlayerState> _obsPlayerState = new();
    List<IObserverButtons> _obsButtons = new();
    [SerializeField] int _states;

    public void ChangeState(int state)
    {
        _states = state;

        foreach (var observer in _obsPlayerState)
        {
            observer.ChangeState(_states);
        }
    }

    public void Jump()
    {
        foreach (var observer in _obsButtons)
        {
            observer.PressButton("Jump");
        }
    }

    #region Suscribirse y Desuscribirse al IObseverPlayerState
    public void Suscribe(IObserverPlayerState obs)
    {
        if (!_obsPlayerState.Contains(obs))
        {
            _obsPlayerState.Add(obs);
        }
    }

    public void Unsuscribe(IObserverPlayerState obs)
    {
        if (_obsPlayerState.Contains(obs))
        {
            _obsPlayerState.Remove(obs);
        }
    }
    #endregion

    #region Suscribirse y Desuscribirse al IObserverButtons
    public void Suscribe(IObserverButtons obs)
    {
        if (!_obsButtons.Contains(obs))
        {
            _obsButtons.Add(obs);
        }
    }

    public void Unsuscribe(IObserverButtons obs)
    {
        if (!_obsButtons.Contains(obs))
        {
            _obsButtons.Remove(obs);
        }
    }
    #endregion
}