using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    SaveData saveData;
    //[SerializeField] SaveText saveText;
    [SerializeField] SavePPrefs savePPrefs;
    //[SerializeField] SaveByJSON save_byJSON;

    void Start()
    {
        saveData = new SaveData();

        /*saveData.SelectSkinBasic = 0;
        saveData.SelectSkinSpike = 0;
        saveData.SelectSkinBounce = 0;
        */
    }

    public void ButtonPlayerPrefSave()
    {
        savePPrefs.Save(saveData);
    }
    public void ButtonPlayerPrefLoad()
    {
        saveData = savePPrefs.Load();
    }
}
