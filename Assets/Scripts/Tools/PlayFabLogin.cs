using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField] private SaveButtons saveButtons;

    private void Start()
    {
        Login();
    }

    private void Login()
    {
        LoginWithCustomIDRequest request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginError);
    }

    private void OnLoginSuccess(LoginResult loginResult)
    {
        Debug.Log("Successfull login");
        saveButtons.SetButtonsActive(true);
    }

    private void OnLoginError(PlayFabError playFabError)
    {
        Debug.Log("Error while login!");
        Debug.Log(playFabError.GenerateErrorReport());
    }
}
