using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    public SaveCheckPoints[] references;

    public void Start()
    {
        StartCoroutine(CorSave());
    }


    public void LoadRef()
    {
        foreach (var reference in references)
        {
            reference.Load();
        }
    }

    IEnumerator CorSave()
    {
        while (true)
        {
            foreach (var reference in references)
            {
                reference.Save();
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
