using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    /*[SerializeField] private string name = "default";
    [SerializeField] private int level = 1;
    [SerializeField] private int currency = 0;
    */
    public int SelectSkinBasic
    {
        get { return MaterialManager.SelectSkinsN; }
        set
        {
            MaterialManager.SelectSkinsN = value;
            //Debug.Log(value);
        }
    }

    public int SelectSkinSpike
    {
        get { return MaterialManager.SelectSkinsS; }
        set
        {
            MaterialManager.SelectSkinsS = value;
            //Debug.Log(value);
        }
    }

    public int SelectSkinBounce
    {
        get { return MaterialManager.SelectSkinsB; }
        set
        {
            MaterialManager.SelectSkinsB = value;
            //Debug.Log(value);
        }
    }


    /*public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public int Currency
    {
        get { return currency; }
        set { currency = value; }
    }

    public SaveData()
    {
        name = "default";
        level = 0;
        currency = 0;
    }*/
}
