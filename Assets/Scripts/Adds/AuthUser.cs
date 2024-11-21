using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Services.Authentication;
using Unity.Services.Authentication.PlayerAccounts;
using Unity.Services.Core;

using TMPro;
using System.Threading.Tasks;

public class AuthUser : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI console;

    public static AuthUser instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    async void Start()
    {
        //inicializar los servicios
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Log("Se logeo correctamente", "green");

            Log("ID " + AuthenticationService.Instance.PlayerInfo.Id, "green");

        };
        AuthenticationService.Instance.SignedOut += () =>
        {

        };
        AuthenticationService.Instance.SignInCodeExpired += () =>
        {

        };
        AuthenticationService.Instance.SignInFailed += requestfailedEx =>
        {
            Log(requestfailedEx.Message, "red");
        };

        //como me logeo, en este caso anonimo
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await SingInAnonimous();
        }

        //PlayerAccountService.Instance.SignedIn += SignInWithUnity;
    }

    public async void StartSignInAsync()
    {
        if (PlayerAccountService.Instance.IsSignedIn)
        {
            SignInWithUnity();
            return;
        }

        try
        {
            Log("Intento Logear");
            await PlayerAccountService.Instance.StartSignInAsync();
        }
        catch (AuthenticationException ex) { Log("AuthenticationException " + ex.Message, "red"); }
        catch (RequestFailedException ex) { Log("RequestFailedException " + ex.Message, "red"); }
    }

    async void SignInWithUnity()
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUnityAsync(PlayerAccountService.Instance.AccessToken);
            Log("Se logeo correctamente", "green");
        }
        catch (AuthenticationException ex) { Log("AuthenticationException " + ex.Message, "red"); }
        catch (RequestFailedException ex) { Log("RequestFailedException " + ex.Message, "red"); }
    }


    void OnSIngIn()
    {

    }

    async Task SingInAnonimous()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Log("ID: " + AuthenticationService.Instance.PlayerInfo.Id);
            Log("Logeo anonimo ", "green");
        }
        catch (AuthenticationException ex) { Log("AuthenticationException " + ex.Message, "red"); }
        catch (RequestFailedException ex) { Log("RequestFailedException " + ex.Message, "red"); }
    }

    public void Log(string _msg, string _color = "white")
    {
        console.text += "\n<color=" + _color + ">" + _msg + "</color>";
    }

}

