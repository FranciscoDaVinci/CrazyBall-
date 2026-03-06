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
            if (reference.isActiveAndEnabled)
                reference.Load();
        }
    }

    IEnumerator CorSave()
    {
        while (true)
        {
            foreach (var reference in references)
            {
                if (reference.isActiveAndEnabled)
                {
                    reference.Save();
                    break;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
