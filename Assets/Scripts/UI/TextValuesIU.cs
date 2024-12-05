using UnityEngine;
using System;
using TMPro;

public class TextValuesIU : MonoBehaviour
{
    [SerializeField] public TMP_Text[] Texts;
    [SerializeField] public bool inGame;


    private void Update()
    {
        if (inGame)
        {
            TimeSpan left = DateTime.Now - LifePlayer.next;
            Texts[2].text = left.Seconds.ToString("00");
            if (DateTime.Now > LifePlayer.next)
            {
                Texts[2].text = 0.ToString();
            }
        }        
    }

    public void SetValue()
    {
        Texts[0].text = ((int)AddsRewarded.Money).ToString();
    }

    public void SetLife()
    {
        Texts[1].text = "x" + ((int)LifePlayer.Lifes).ToString() + "/" + ((int)LifePlayer.maxLife).ToString();        
    }
}
