using UnityEngine;


public class LoadScenes : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadScene()
    {
        SceneLoadManager.LoadScene(sceneToLoad);
    }
}
