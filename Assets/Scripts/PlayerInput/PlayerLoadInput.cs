using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLoadInput : MonoBehaviour, IInputAbility
{
    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        PlayFabTools.LoadGame();
    }
}
