using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour, IInputAbility
{
    [SerializeField] private GameObject inventoryUI;

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        inventoryUI.SetActive(true);
    }
}
