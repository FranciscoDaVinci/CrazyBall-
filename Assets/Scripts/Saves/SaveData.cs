using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    [SerializeField] private string name = "default";
    [SerializeField] private int level = 1;
    [SerializeField] private int currency = 0;


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Level
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
    }
}
