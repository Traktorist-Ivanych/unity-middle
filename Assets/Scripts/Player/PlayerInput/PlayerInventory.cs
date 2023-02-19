using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour, IInputAbility, IFactoryCreation
{
    [SerializeField] private Canvas inventoryUI;

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        inventoryUI.enabled = true;
    }

    public void OnInstantiation(Object instantiatedObject)
    {
        inventoryUI = instantiatedObject as Canvas;
    }
}
