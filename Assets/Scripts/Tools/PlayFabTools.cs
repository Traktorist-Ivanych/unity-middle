using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public static class PlayFabTools
{
    public delegate void IsSaveButtonActive(bool flag);
    public static IsSaveButtonActive OnLoadStart;
    public static IsSaveButtonActive OnSaveEnd;

    public static void SaveGame(string dataToSave)
    {
        UpdateUserDataRequest updateRequest = new UpdateUserDataRequest 
        {
            Data = new Dictionary<string, string>
            {
                {"SavedData", dataToSave }
            }
        };
        PlayFabClientAPI.UpdateUserData(updateRequest, OnUpdateSuccess, OnError);
    }

    public static void LoadGame()
    {
        OnLoadStart(false);
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnLoadGame, OnError);
    }

    private static void OnLoadGame(GetUserDataResult getedResult)
    {
        if (getedResult != null && getedResult.Data.ContainsKey("SavedData"))
        {
            SavesManager.LoadedGameData = getedResult.Data["SavedData"].Value;
            Debug.Log("Successfull loaded");
            SavesManager.LoadGame();
        }
    }

    private static void OnUpdateSuccess(UpdateUserDataResult updateResult)
    {
        Debug.Log("Successfull update");
        OnSaveEnd?.Invoke(true);
    }

    private static void OnError(PlayFabError playFabError)
    {
        Debug.Log("Error while login!");
        Debug.Log(playFabError.GenerateErrorReport());
    }
}
