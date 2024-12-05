using UnityEngine;

public class SavePPrefs : BaseSave
{

    public override SaveData OnLoad()
    {
        SaveData data = new SaveData();

        data.SelectSkinBasic = PlayerPrefs.GetInt("SkinBase", 0);
        data.SelectSkinSpike = PlayerPrefs.GetInt("SkinSpike", 0);
        data.SelectSkinBounce = PlayerPrefs.GetInt("SkinBounce", 0);
        data.AdsViews = PlayerPrefs.GetInt("AdsViews", 0);
        data.Money = PlayerPrefs.GetInt("Money", 0);
        data.Lifes = PlayerPrefs.GetInt("Lifes", 5);
        data.TimetoAddLife = PlayerPrefs.GetString("LifeTime");


        Debug.Log("Se cargo la Skin Normal numero " + data.SelectSkinBasic);
        Debug.Log("Se cargo la Skin Spike numero " + data.SelectSkinSpike);
        Debug.Log("Se cargo la Skin Bounce numero " + data.SelectSkinBounce);
        Debug.Log("El valor de comprado 0/1 se carga en " + data.AdsViews);
        Debug.Log("La cantidad de monedas cargadas es " + data.Money);
        Debug.Log("La cantidad de vidas cargadas es de " + data.Lifes);


        return data;
    }

    public override void OnSave(SaveData data)
    {
        PlayerPrefs.SetInt("SkinBase", data.SelectSkinBasic);
        PlayerPrefs.SetInt("SkinSpike", data.SelectSkinSpike);
        PlayerPrefs.SetInt("SkinBounce", data.SelectSkinBounce);
        PlayerPrefs.SetInt("AdsViews", data.AdsViews);
        PlayerPrefs.SetInt("Money", data.Money);
        PlayerPrefs.SetInt("Lifes", data.Lifes);
        PlayerPrefs.SetString("LifeTime", data.TimetoAddLife);

        Debug.Log("Se guardo la Skin Normal numero " + data.SelectSkinBasic);
        Debug.Log("Se guardo la Skin Spike numero " + data.SelectSkinSpike);
        Debug.Log("Se guardo la Skin Bounce numero " + data.SelectSkinBounce);
        Debug.Log("El valor de comprado 0/1 se guarda en " + data.AdsViews);
        Debug.Log("La cantidad de monedas guardadas es " + data.Money);
        Debug.Log("La cantidad de vidas cargadas es de " + data.Lifes);
    }
}
