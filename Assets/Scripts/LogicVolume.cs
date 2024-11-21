using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicVolume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image mute;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumeAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();


    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumeAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();

    }

    public void RevisarSiEstoyMute()
    {
        if(sliderValue == 0)
        {
            mute.enabled = true;
        }
        else
        {
            mute.enabled = false;
        }
    }

}
