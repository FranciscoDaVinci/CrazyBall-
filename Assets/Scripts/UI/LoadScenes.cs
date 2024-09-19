using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
