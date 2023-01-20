using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavesManager
{
    public delegate void SaveManagerDelegate();
    public static SaveManagerDelegate SaveGameEvent;
    public static SaveManagerDelegate LoadGameEvent;
    public static List<ObjectData> ObjectsDataList = new List<ObjectData>();

    public static void SaveGame()
    {
        SaveGameEvent?.Invoke();

        string savedData = JsonUtility.ToJson(ObjectsDataList);

        GoogleDriveTools.Upload(savedData);
    }

    public static void LoadGame()
    {
        LoadGameEvent?.Invoke();
    }

    [Serializable]
    public class ObjectData
    {
        public string ID;
        public string DATE;

        public ObjectData(string _Key, string _Date)
        {
            ID = _Key;
            DATE = _Date;
        }
    }
}
