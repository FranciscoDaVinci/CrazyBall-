using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour, IObservablePlayerState, IObservableButtons
{
    List<IObserverPlayerState> _obsPlayerState = new();
    List<IObserverButtons> _obsButtons = new();
    [SerializeField] int _states;
    [SerializeField] GameObject jumpButton;
    [SerializeField] GameObject dashButton;

    public void ChangeState(int state)
    {
        if (TutorialManager.Instance != null)
        {
            // Mientras no se habiliten las pelotas
            if (!TutorialManager.Instance.CanChangeBall())
                return;

            // En el paso Bounce no permitir Spike
            if (state == 2 && !TutorialManager.Instance.CanUseSpike())
                return;
        }

        _states = state;

        foreach (var observer in _obsPlayerState)
        {
            observer.ChangeState(_states);
        }

        // Actualizar la interfaz
        switch (state)
        {
            // Normal
            case 0:
                jumpButton.SetActive(false);
                dashButton.SetActive(true);
                break;

            // Bounce
            case 1:
                jumpButton.SetActive(true);
                dashButton.SetActive(false);
                break;

            // Spike
            case 2:
                jumpButton.SetActive(false);
                dashButton.SetActive(true);
                break;
        }
    }

    public void Jump()
    {
        foreach (var observer in _obsButtons)
        {
            observer.PressButton("Jump");
        }
    }

    public void Dash()
    {
        foreach (var observer in _obsButtons)
        {
            observer.PressButton("Dash");
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
        if (_obsButtons.Contains(obs))
        {
            _obsButtons.Remove(obs);
        }
    }
    #endregion
}