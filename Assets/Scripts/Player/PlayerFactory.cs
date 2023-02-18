using Photon.Pun;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private MonoBehaviour[] factoryCreationScripts;
    [SerializeField] private Transform[] spawnPositions;

    [Header("Scripts for instantiated player")]
    [SerializeField] private SaveLoadConfiguration saveLoadConfiguration;
    [SerializeField] private ViewModel viewModel;
    [SerializeField] private GameObject inventoryUI;

    public void CreatePlayer()
    {
        GameObject instantiatedObject = PhotonNetwork.Instantiate(
            player.name, spawnPositions[PhotonNetwork.LocalPlayer.ActorNumber - 1].position, Quaternion.identity);

        foreach (MonoBehaviour factoryCreationScript in factoryCreationScripts)
        {
            (factoryCreationScript as IFactoryCreation).OnInstantiation(instantiatedObject);
        }

        MonoBehaviour[] playerScripts = instantiatedObject.GetComponents<MonoBehaviour>();

        foreach(MonoBehaviour playerInput in playerScripts)
        {
            if (playerInput is PlayerSaveInput || playerInput is PlayerLoadInput)
            {
                (playerInput as IFactoryCreation).OnInstantiation(saveLoadConfiguration);
            }
            else if (playerInput is HealthScrollBar)
            {
                (playerInput as IFactoryCreation).OnInstantiation(viewModel);
            }
            else if (playerInput is PlayerInventory)
            {
                (playerInput as IFactoryCreation).OnInstantiation(inventoryUI);
            }
        }
    }
}
