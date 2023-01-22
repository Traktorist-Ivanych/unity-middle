using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableObject : MonoBehaviour, ISavableObject
{
    [SerializeField] protected string id;

    public string Id => id;

    private void Start()
    {
        if (id == string.Empty)
        {
            Debug.LogError("Id is empty! GameObject.Name = " + gameObject.name);
        }

        SavesManager.SaveGameEvent += Save;
        SavesManager.LoadGameEvent += Load;

        AddToSavableObjectsLict();

        OnStart();
    }

    protected virtual void OnStart()
    {
        Debug.Log("Void OnStart SavableObject Empty!");
    }

    public void AddToSavableObjectsLict()
    {
        CheckAllId.SavableObjectsList.Add(this);
    }

    public virtual void Load()
    {
        Debug.Log("Void Load SavableObject Empty!");
    }

    public virtual void Save()
    {
        Debug.Log("Void Save SavableObject Empty!");
    }
}
