using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLoadInput : MonoBehaviour, IInputAbility, IFactoryCreation
{
    [SerializeField] private SaveLoadConfiguration saveLoadConfiguration;

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        PlayFabTools.LoadGame();
        saveLoadConfiguration.LoadConfiguration();
    }

    public void OnInstantiation(Object instantiatedObject)
    {
        if (instantiatedObject is SaveLoadConfiguration)
        {
            saveLoadConfiguration = instantiatedObject as SaveLoadConfiguration;
        }
    }
}
