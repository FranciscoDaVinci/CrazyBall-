using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject gameOverUI2;

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        gameOverUI2.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;

    }

    public void Menu()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;

    }

    public void Resume(GameObject gameObject)
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;

    }

    public void Pause(GameObject gameObject)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
