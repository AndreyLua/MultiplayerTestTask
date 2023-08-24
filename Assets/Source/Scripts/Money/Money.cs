using Photon.Pun;
using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    private int _value = 5;
    public int Value => _value;

    public event Action<Vector3> MoneyCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ICollector>(out ICollector collector))
        {
            collector.TakeMoney(_value);
            PhotonView photonView = gameObject.GetComponent<PhotonView>();
            photonView.RPC("CollectedMoney", RpcTarget.AllBuffered, photonView.transform.position);
            PhotonMasterClient.DeleteMasterClientObject(photonView);
        }
    }

    [PunRPC]
    private void CollectedMoney(Vector3 moneyPosition)
    {
        MoneyCollected?.Invoke(moneyPosition);
    }

    [PunRPC]
    private void DeleteServerObject(int idObject)
    {
        PhotonNetwork.Destroy(PhotonView.Find(idObject));
    }
}
