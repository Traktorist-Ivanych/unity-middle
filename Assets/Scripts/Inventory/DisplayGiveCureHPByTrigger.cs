using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DisplayGiveCureHPByTrigger : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private GameObject inventoryItemUI;
    [SerializeField] private GameObject inventoryGrid;
    private Health health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && other.TryGetComponent<Health>(out health) &&
            health.IsNeedForCure)
        {
            GameObject inventoryItem = Instantiate(inventoryItemUI, inventoryGrid.transform);
            inventoryItem.GetComponent<IInventoryActionItem>().OnItemInstantiation(health);

            gameObject.SetActive(false);
        }
    }
}
