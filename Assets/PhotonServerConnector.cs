using Photon.Pun;
using System;

public class PhotonServerConnector : MonoBehaviourPunCallbacks
{
    public event Action ConnectedToMascter;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        ConnectedToMascter?.Invoke();
    }
}
