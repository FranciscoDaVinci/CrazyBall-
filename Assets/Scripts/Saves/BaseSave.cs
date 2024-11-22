using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSave : MonoBehaviour
{
    public void Save(SaveData data)
    {
        OnSave(data);
    }
    public SaveData Load()
    {
        return OnLoad();
    }

    public abstract void OnSave(SaveData data);
    public abstract SaveData OnLoad();
}
