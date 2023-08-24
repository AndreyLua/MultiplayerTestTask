using Photon.Pun;

public class PhotonMasterClient
{
    [PunRPC]
    private void DeleteServerObject(int idObject)
    {
        PhotonNetwork.Destroy(PhotonView.Find(idObject));
    }
}