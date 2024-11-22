using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    SaveData saveData;

    [SerializeField] SaveText saveText;
    //[SerializeField] SaveByPlayerPrefs save_byPrefs;
    //[SerializeField] SaveByJSON save_byJSON;


    void Start()
    {
        saveData = new SaveData();

        saveData.Name = "default";
        saveData.Level = 0;
        saveData.Currency = 0;
    }

    public void ButtonTxtSave()
    {
        saveText.Save(saveData);
    }
    public void ButtonTxtLoad()
    {
        saveData = saveText.Load();
    }
}
