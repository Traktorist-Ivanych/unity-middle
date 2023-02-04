using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLoadInput : MonoBehaviour, IInputAbility
{
    [SerializeField] private SaveLoadConfiguration saveLoadConfiguration;

    public async void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        PlayFabTools.LoadGame();
        await saveLoadConfiguration.LoadConfiguration();
    }
}
