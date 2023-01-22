using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFirstAidKit : SavableObject
{
    private FirstAidKit firstAidKit;

    protected override void OnStart()
    {
        firstAidKit = GetComponent<FirstAidKit>();
    }

    public override void Save()
    {
        FirstAidKitDataToSave healthDataToSave = new FirstAidKitDataToSave(firstAidKit.IsUsed);
        string savedData = JsonUtility.ToJson(healthDataToSave);
        SavesManager.AddObjectDataIntoList(id, savedData);
    }

    public override void Load()
    {
        FirstAidKitDataToSave loadedData = JsonUtility.FromJson<FirstAidKitDataToSave>(SavesManager.GetObjectData(id));
        if (loadedData != null)
        {
            firstAidKit.ActiveOrNot(loadedData.IsFirstAidKitUsed);
        }
    }

    [Serializable]
    private class FirstAidKitDataToSave
    {
        public bool IsFirstAidKitUsed;

        public FirstAidKitDataToSave(bool isUsed)
        {
            IsFirstAidKitUsed = isUsed;
        }
    }
}
