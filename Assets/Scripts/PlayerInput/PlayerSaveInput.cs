using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSaveInput : MonoBehaviour, IInputAbility
{
    [SerializeField] private SaveLoadConfiguration saveLoadConfiguration;

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        SavesManager.SaveGame();
        saveLoadConfiguration.SaveConfiguration();
    }
}
