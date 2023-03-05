using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class DisplayRaiseJerkSpeedByTrigger : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private GameObject inventoryItemUI;
    [SerializeField] private GameObject inventoryGrid;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip takeObject;
    private PlayerJerk playerJerk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && other.TryGetComponent<PlayerJerk>(out playerJerk))
        {
            GameObject inventoryItem = Instantiate(inventoryItemUI, inventoryGrid.transform);
            inventoryItem.GetComponent<IInventoryActionItem>().OnItemInstantiation(playerJerk);

            audioSource.PlayOneShot(takeObject);

            gameObject.SetActive(false);
        }
    }
}
