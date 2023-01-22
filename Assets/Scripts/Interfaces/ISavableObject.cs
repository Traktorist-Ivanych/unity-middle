using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavableObject
{
    public string Id { get; }

    public void Save();

    public void Load();

    public void AddToSavableObjectsLict();
}
