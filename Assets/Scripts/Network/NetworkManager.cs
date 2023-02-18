using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private PlayerFactory playerFactory;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions
        {
            MaxPlayers = 2,
            IsVisible = true
        };

        PhotonNetwork.JoinOrCreateRoom("TolerantNiggas", options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        playerFactory.CreatePlayer();
    }
}
