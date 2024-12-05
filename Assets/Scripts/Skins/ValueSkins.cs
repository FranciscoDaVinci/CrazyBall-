using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueSkins : MonoBehaviour
{
    public static int SelectSkinsN;
    public static int SelectSkinsS;
    public static int SelectSkinsB;

    [SerializeField]MaterialManager mManager;
    public int skinValue;
    //public int isbuyed;
    public static int buyed;
    public GameObject Reward;
    public GameObject Obtained;
    public GameObject[] NotObtained;

    /*public void Awake()
    {
        buyed = isbuyed;
        if (isbuyed == 1)
        {
            skinValue = 0;
        }        
    }*/

    public void SkinNormal(int value)
    {
        if (skinValue <= AddsRewarded.Money)
        {
            mManager.SkinSelectorNormal(value);
            AddsRewarded.Money -= skinValue;
            skinValue = 0;
            Obtained.SetActive(true);
            buyed = 1;
            Debug.Log("Esta comprado, vale " + buyed);
            for (int i = 0; i < NotObtained.Length; i++)
            {
                NotObtained[i].SetActive(false);
            }
            
        }
        else
        {
            Reward.SetActive(true);
            Debug.Log("No tiene el dinero suficiente como para comprar esta Skin");
        }
    }

    public void SkinSpike(int value)
    {
        if (skinValue <= AddsRewarded.Money)
        {
            mManager.SkinSelectorSpike(value);
            AddsRewarded.Money -= skinValue;
            skinValue = 0;
            Obtained.SetActive(true);
            buyed = 1;
            Debug.Log("La skin ahora vale" + skinValue);
            for (int i = 0; i < NotObtained.Length; i++)
            {
                NotObtained[i].SetActive(false);
            }
        }
        else
        {
            Reward.SetActive(true);
            Debug.Log("No tiene el dinero suficiente como para comprar esta Skin");
        }
    }

    public void SkinBounce(int value)
    {
        if (skinValue <= AddsRewarded.Money)
        {
            mManager.SkinSelectorBounce(value);
            AddsRewarded.Money -= skinValue;
            skinValue = 0;
            Obtained.SetActive(true);
            buyed = 1;
            Debug.Log("La skin ahora vale" + skinValue);
            for (int i = 0; i < NotObtained.Length; i++)
            {
                NotObtained[i].SetActive(false);
            }
        }
        else
        {
            Reward.SetActive(true);
            Debug.Log("No tiene el dinero suficiente como para comprar esta Skin");
        }
    }
}
