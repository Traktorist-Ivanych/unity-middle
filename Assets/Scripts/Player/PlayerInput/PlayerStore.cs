using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStore : MonoBehaviour, IInputAbility, IFactoryCreation
{
    [SerializeField] private Canvas storeUI;

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        storeUI.enabled = true;
    }

    public void OnInstantiation(Object instantiatedObject)
    {
        storeUI = instantiatedObject as Canvas;
    }
}
