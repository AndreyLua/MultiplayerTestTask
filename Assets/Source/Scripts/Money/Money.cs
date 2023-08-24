using Photon.Pun;
using UnityEngine;

public class Money : MonoBehaviour
{
    private int _value = 5;
    public int Value => _value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ICollector>(out ICollector collector))
        {
            collector.TakeMoney(_value);
            PhotonView photonView = gameObject.GetComponent<PhotonView>();
            PhotonMasterClient.DeleteMasterClientObject(photonView);
        }
    }
    [PunRPC]
    private void DeleteServerObject(int idObject)
    {
        PhotonNetwork.Destroy(PhotonView.Find(idObject));
    }
}
