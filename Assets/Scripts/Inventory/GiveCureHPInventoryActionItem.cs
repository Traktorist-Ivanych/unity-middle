using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GiveCureHPInventoryActionItem : MonoBehaviour, IInventoryActionItem
{
    [SerializeField] private float givingHpValue;
    private Button inventoryButtonUI;
    private Health health;

    private void Start()
    {
        inventoryButtonUI = GetComponent<Button>();
        inventoryButtonUI.onClick.AddListener(ExecuteInventoryAction);
    }

    public void ExecuteInventoryAction()
    {
        health.GetCureHp(givingHpValue);
        Destroy(gameObject);
    }

    public void OnItemInstantiation(MonoBehaviour targetActionScpipt)
    {
        health = targetActionScpipt as Health;
    }
}
