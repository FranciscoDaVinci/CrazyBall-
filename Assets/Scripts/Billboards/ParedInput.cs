using UnityEngine;

public class ParedInput : MonoBehaviour
{
    //public bool ballSpike = false;
    public Controller controller;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.name != "SpikeState")
        {
            controller.WallOn1();
            //ballSpike = true;
        }
        else
        {
            controller.WallOff1();
            //ballSpike = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        controller.WallOff1();
        //ballSpike = false;        
    }
}
