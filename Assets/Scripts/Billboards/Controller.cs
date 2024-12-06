using UnityEngine;

public class Controller : MonoBehaviour
{
    public ParedInput paredScript;
    public ParedInput2 paredScript2;
    public View viewScript;

    public void WallOn1()
    {
        viewScript.Billboards[0].SetActive(true);
    }

    public void WallOff1()
    {
        viewScript.Billboards[0].SetActive(false);
    }

    public void WallOn2()
    {
        viewScript.Billboards[1].SetActive(true);
    }

    public void WallOff2()
    {
        viewScript.Billboards[1].SetActive(false);
    }


    public void Win()
    {
        viewScript.Billboards[2].SetActive(true);
        Time.timeScale = 0;
    }

    public void NotWinYet()
    {
        viewScript.Billboards[2].SetActive(false);
    }
}
