using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LifePlayer : MonoBehaviour
{
    public static int Lifes;
    public static int maxLife;
    public int maxLifeValue;
    public float rechargeTime;
    public static DateTime next;
    public TextValuesIU txtValue;
    Coroutine corrutine;
    //[SerializeField] GameObject noHearts;

    public void Start()
    {
        if (RemoteConfigManager.IsReady)
        {
            ApplyRemoteSettings(RemoteConfigManager.MaxLives);
        }
        else
        {
            maxLife = maxLifeValue;
            RemoteConfigManager.ConfigApplied += OnRemoteConfigApplied;
        }
        corrutine = StartCoroutine(UpdateLife());
        txtValue.SetLife();
    }
    void OnDestroy()
    {
        RemoteConfigManager.ConfigApplied -= OnRemoteConfigApplied;
    }
    void OnRemoteConfigApplied()
    {
        if (RemoteConfigManager.IsReady)
        {
            ApplyRemoteSettings(RemoteConfigManager.MaxLives);
        }
    }
    public void ApplyRemoteSettings(int maxLives)
    {
        maxLifeValue = maxLives;
        maxLife = maxLives;
        if (Lifes > maxLifeValue)
        {
            Lifes = maxLifeValue;
        }
        txtValue.SetLife();
    }

    IEnumerator UpdateLife()
    {
        while (Lifes < maxLifeValue)
        {

            while (DateTime.Now > next)
            {
                RechargeLife(1);
            }

            txtValue.SetLife();
            yield return new WaitForEndOfFrame();
        }
        corrutine = null;   
    }

    public void RechargeLife(int value)
    {
        Lifes += value;

        if (Lifes >= maxLifeValue)
        {
            Lifes = maxLife;
            next = DateTime.Now;
        }

        else
        {
            if (DateTime.Now > next)
            {
                next = next.AddSeconds(rechargeTime);
            }
            else
            {
                next = DateTime.Now.AddSeconds(rechargeTime);
            }
        }

        txtValue.SetLife();
    }


    public void RestLife(int value)
    {
        if (Lifes - value >= 0)
        {
            Lifes -= value;
        }

        if (Lifes < maxLife)
        {
            if (DateTime.Now > next)
            {
                next = DateTime.Now.AddSeconds(rechargeTime);
            }            

            if(corrutine == null)   
            corrutine = StartCoroutine(UpdateLife());
        }

        txtValue.SetLife();
    }
}
