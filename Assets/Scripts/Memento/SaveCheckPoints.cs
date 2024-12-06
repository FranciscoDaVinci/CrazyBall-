using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveCheckPoints : MonoBehaviour
{
    protected CheckPoints _checkPoints;

    private void Awake()
    {
        _checkPoints = new CheckPoints();
    }

    public abstract void Load();
    public abstract void Save();

}
