using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RaiseJerkSpeedInventoryActionItem : MonoBehaviour, IInventoryActionItem
{
    [SerializeField] private float raiseJekrSpeedValue;
    private Button inventoryButtonUI;
    private PlayerJerk playerJerk;

    private void Start()
    {
        inventoryButtonUI = GetComponent<Button>();
        inventoryButtonUI.onClick.AddListener(ExecuteInventoryAction);
    }

    public void ExecuteInventoryAction()
    {
        playerJerk.RaiseJerkSpeed(raiseJekrSpeedValue);
        Destroy(gameObject);
    }

    public void OnItemInstantiation(MonoBehaviour targetActionScpipt)
    {
        playerJerk = targetActionScpipt as PlayerJerk;
    }
}
