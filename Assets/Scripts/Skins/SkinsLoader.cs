using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsLoader : MonoBehaviour
{
    public Renderer[] Players;
    //public Renderer PlayerBounce;
    public MaterialManager matManager;
    //public MaterialManager[] mat2;

    void Start()
    {
        Debug.Log("La pelota normal cargada es la numero " + matManager.BallsTypes[0]);

        for (int i=0; i < Players.Length; i++)
        {
            {
                Players[i].material = matManager.BallsTypes[i];
                //Debug.Log("La pelota numero " + i + " tiene un valor de " + matManager.BallsTypes[i]);
            }
            //Debug.Log("Entro aca, seleccionando la skin numero " + MaterialManager.SelectSkinsN);
        }

        //Renderer render = Player.GetComponent<Renderer>();

        //if (Players != null)

        /*else
        {
            Debug.Log("Seguimos en el menu");
        }*/
    }
}
