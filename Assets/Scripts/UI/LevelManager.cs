using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
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

    public void ExitG()
    {
        Debug.Log("Cerrando");
        Application.Quit();
    }
}
