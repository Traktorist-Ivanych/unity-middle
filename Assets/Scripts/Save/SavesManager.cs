using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavesManager
{
    public delegate void SaveManagerDelegate();
    public static SaveManagerDelegate SaveGameEvent;
    public static SaveManagerDelegate LoadGameEvent;

    public delegate void IsSaveButtonActive(bool flag);
    public static IsSaveButtonActive OnSaveStart;
    public static IsSaveButtonActive OnLoadEnd;

    public static ObjectsData SavedObjectsData = new ObjectsData();

    public static string LoadedGameData;

    public static void SaveGame()
    {
        OnSaveStart?.Invoke(false);
        SavedObjectsData.ObjectsDataList.Clear();
        SaveGameEvent?.Invoke();

        string savedData = JsonUtility.ToJson(SavedObjectsData);

        PlayFabTools.SaveGame(savedData);
    }

    public static void AddObjectDataIntoList(string objectId, string objectData)
    {
        SavedObjectsData.ObjectsDataList.Add(new ObjectData(objectId, objectData));
    }

    public static void LoadGame()
    {
        SavedObjectsData = JsonUtility.FromJson<ObjectsData>(LoadedGameData);
        LoadGameEvent?.Invoke();
        OnLoadEnd?.Invoke(true);
    }

    public static string GetObjectData(string idForSearch)
    {
        foreach (ObjectData objectData in SavedObjectsData.ObjectsDataList)
        {
            if (objectData.Id == idForSearch)
            {
                return objectData.Data;
            }
        }
        return string.Empty;
    }

    [Serializable]
    public class ObjectData
    {
        public string Id;
        public string Data;

        public ObjectData(string objectId, string objectDate)
        {
            Id = objectId;
            Data = objectDate;
        }
    }

    [Serializable]
    public class ObjectsData
    {
        public List<ObjectData> ObjectsDataList = new List<ObjectData>();
    }
}
