using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    private Transform cameraTransform;
    private Transform cameraLookAt;
    
    public GameObject levelbuttonPrefab;
    public GameObject levelbuttonControl;
    public string sceneToLoad;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        Sprite[] miniaturas = Resources.LoadAll<Sprite>("Levels");
        foreach (Sprite miniatura in miniaturas)
        {
            GameObject control = Instantiate(levelbuttonPrefab) as GameObject;
            control.GetComponent<Image>().sprite = miniatura;
            control.transform.SetParent(levelbuttonControl.transform, false);

            
        }
    }

    private void Update()
    {
        if(cameraLookAt != null)
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraLookAt.rotation, 3 * Time.deltaTime);
        }
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LookAtMenu(Transform menuTransform)
    {
        cameraLookAt = menuTransform;
    }
}
