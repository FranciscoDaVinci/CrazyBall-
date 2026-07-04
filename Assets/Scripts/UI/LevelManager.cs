using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Restart()
    {
        SceneLoadManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        ConfirmationManager.Show(
            "¿Volver al menu principal?",
            () => SceneLoadManager.LoadScene("MainMenu"));
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
        ConfirmationManager.Show(
            "¿Salir del juego?",
            () =>
            {
                var saveManager = FindObjectOfType<SaveManager>();
                if (saveManager != null)
                {
                    saveManager.ButtonPlayerPrefSave();
                }

                Debug.Log("Cerrando");
                Application.Quit();
            });
    }
}
