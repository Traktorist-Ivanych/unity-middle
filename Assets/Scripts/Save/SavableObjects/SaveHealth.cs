using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHealth : SavableObject
{
    private Health healthToSave;

    protected override void OnStart()
    {
        healthToSave = GetComponent<Health>();
    }

    public override void Save()
    {
        HealthDataToSave healthDataToSave = new HealthDataToSave(healthToSave.CurrentHp);
        string savedData = JsonUtility.ToJson(healthDataToSave);
        SavesManager.AddObjectDataIntoList(id, savedData);
    }

    public override void Load()
    {
        HealthDataToSave loadedData = JsonUtility.FromJson<HealthDataToSave>(SavesManager.GetObjectData(id));
        if (loadedData != null)
        {
            healthToSave.CurrentHp = loadedData.currentHp;
        }
    }

    [Serializable]
    private class HealthDataToSave
    {
        public float currentHp;

        public HealthDataToSave(float hp)
        {
            currentHp = hp;
        }
    }
}
