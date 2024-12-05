using UnityEngine;

public class SaveData
{

    public int SelectSkinBasic
    {
        get { return MaterialManager.SelectSkinsN; }
        set
        {
            MaterialManager.SelectSkinsN = value;
        }
    }

    public int SelectSkinSpike
    {
        get { return MaterialManager.SelectSkinsS; }
        set
        {
            MaterialManager.SelectSkinsS = value;
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

    public int AdsViews
    {
        get { return ValueSkins.buyed; }
        set
        {
            ValueSkins.buyed = value;
        }
    }

    public int Money
    {
        get { return AddsRewarded.Money; }
        set
        {
            AddsRewarded.Money = value;
        }
    }

    public int Lifes
    {
        get { return LifePlayer.Lifes; }
        set
        {
            LifePlayer.Lifes = value;
        }
    }

    public string TimetoAddLife
    {
        get { return LifePlayer.next.ToString(); }
        set
        {
        }
    }


    /*public SaveData()
    {
        name = "default";
        level = 0;
        currency = 0;
    }*/
}
