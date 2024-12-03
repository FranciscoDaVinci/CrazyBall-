using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePPrefs : BaseSave
{

    public override SaveData OnLoad()
    {
        SaveData data = new SaveData();
        data.SelectSkinBasic = PlayerPrefs.GetInt("SkinBase", 0);
        data.SelectSkinSpike = PlayerPrefs.GetInt("SkinSpike", 0);
        data.SelectSkinBounce = PlayerPrefs.GetInt("SkinBounce", 0);
        Debug.Log("Se cargo la Skin Normal numero " + data.SelectSkinBasic);
        Debug.Log("Se cargo la Skin Spike numero " + data.SelectSkinSpike);
        Debug.Log("Se cargo la Skin Bounce numero " + data.SelectSkinBounce);

        return data;
    }

    public override void OnSave(SaveData data)
    {
        PlayerPrefs.SetInt("SkinBase", data.SelectSkinBasic);
        PlayerPrefs.SetInt("SkinSpike", data.SelectSkinSpike);
        PlayerPrefs.SetInt("SkinBounce", data.SelectSkinBounce);
        Debug.Log("Se guardo la Skin Normal numero " + data.SelectSkinBasic);
        Debug.Log("Se guardo la Skin Spike numero " + data.SelectSkinSpike);
        Debug.Log("Se guardo la Skin Bounce numero " + data.SelectSkinBounce);
    }
}
