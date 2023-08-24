using Photon.Pun;

public class PhotonMasterClient
{
    public static void DeleteMasterClientObject(PhotonView photonView)
    {
         if (photonView.IsMine)
                PhotonNetwork.Destroy(photonView);
            else
                photonView.RPC("DeleteServerObject", RpcTarget.MasterClient, photonView.ViewID);
    }
}