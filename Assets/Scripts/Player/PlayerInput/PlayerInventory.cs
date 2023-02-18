using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour, IInputAbility, IFactoryCreation
{
    [SerializeField] private GameObject inventoryUI;

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        inventoryUI.SetActive(true);
    }

    public void OnInstantiation(Object instantiatedObject)
    {
        inventoryUI = instantiatedObject as GameObject;
    }
}
