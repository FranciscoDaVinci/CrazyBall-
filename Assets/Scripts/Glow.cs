using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glow : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image glow;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("glow", 0.5f);

        glow.color = new Color(glow.color.r, glow.color.g, glow.color.b, slider.value);

    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("glow", sliderValue);
        glow.color = new Color(glow.color.r, glow.color.g, glow.color.b, slider.value);

    }

}
