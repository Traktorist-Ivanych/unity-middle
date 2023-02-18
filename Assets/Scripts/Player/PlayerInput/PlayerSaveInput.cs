using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSaveInput : MonoBehaviour, IInputAbility, IFactoryCreation
{
    [SerializeField] private SaveLoadConfiguration saveLoadConfiguration;

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        SavesManager.SaveGame();
        saveLoadConfiguration.SaveConfiguration();
    }

    public void OnInstantiation(Object instantiatedObject)
    {
        if (instantiatedObject is SaveLoadConfiguration)
        {
            saveLoadConfiguration = instantiatedObject as SaveLoadConfiguration;
        }
    }
}
