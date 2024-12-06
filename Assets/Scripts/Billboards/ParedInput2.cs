using UnityEngine;

public class ParedInput2 : MonoBehaviour
{
    //public bool ballBounce = false;
    public Controller controller;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.name != "PlayerBounce")
        {
            //ballBounce = true;
            controller.WallOn2();
        }
        else
        {
            controller.WallOff2();
            //ballBounce = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        controller.WallOff2();
        //ballBounce = false;
    }
}
