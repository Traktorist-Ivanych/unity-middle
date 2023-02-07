using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DisplayRaiseJerkSpeedByTrigger : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private GameObject inventoryItemUI;
    [SerializeField] private GameObject inventoryGrid;
    private PlayerJerk playerJerk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && other.TryGetComponent<PlayerJerk>(out playerJerk))
        {
            GameObject inventoryItem = Instantiate(inventoryItemUI, inventoryGrid.transform);
            inventoryItem.GetComponent<IInventoryActionItem>().OnItemInstantiation(playerJerk);

            gameObject.SetActive(false);
        }
    }
}
