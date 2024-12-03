using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static int SelectSkinsN;
    public static int SelectSkinsS;
    public static int SelectSkinsB;

    //public int Valores;
    public Material[] SkinsNormalBalls;
    public Material[] SkinsSpikeBall;
    public Material[] SkinsBounceBall;
    public Material[] BallsTypes;


    private void Awake()
    {
        BallsTypes[0] = SkinsNormalBalls[SelectSkinsN];
        BallsTypes[1] = SkinsSpikeBall[SelectSkinsS];
        BallsTypes[2] = SkinsBounceBall[SelectSkinsB];
    }

    public void SkinSelectorNormal(int SelectSkinNormal)
    {
        SelectSkinsN = SelectSkinNormal;
        BallsTypes[0] = SkinsNormalBalls[SelectSkinsN];
        Debug.Log("La Skin seleccionada para la pelota Normal es es la numero " + SelectSkinsN);
    }

    public void SkinSelectorSpike(int SelectSkinSpike)
    {
        BallsTypes[1] = SkinsSpikeBall[SelectSkinsS];
        SelectSkinsS = SelectSkinSpike;
        Debug.Log("La Skin seleccionada para la pelota Spike es es la numero " + SelectSkinsS);
    }

    public void SkinSelectorBounce(int SelectSkinBounce)
    {
        BallsTypes[2] = SkinsBounceBall[SelectSkinsB];
        SelectSkinsB = SelectSkinBounce;
        Debug.Log("La Skin seleccionada para la pelota Bounce es es la numero " + SelectSkinsB);
    }



    /*public void LoadSkins()
    {
        Renderer render = Player.GetComponent<Renderer>();
        render.material = Skins[SelectSkins];
        Debug.Log(Skins[SelectSkins]);
    }*/
}
