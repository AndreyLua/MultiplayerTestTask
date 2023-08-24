using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] private Money _moneyPrefab;
    [SerializeField] private int _count;

    private List<Vector3> _moneysPosition;
    private Money[] _moneys;

    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _moneysPosition = new List<Vector3>();
            SpawnNewMoney();
        }
    }

    public void SpawnNewMoney()
    {
        Vector3 scale = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) ;

        for (int i = 0; i < _count; i++)
        {
            Vector3 startPosition = new Vector3(Random.Range(-scale.x, scale.x), Random.Range(-scale.y, scale.y), -1);
            GameObject money = PhotonNetwork.Instantiate(_moneyPrefab.name, startPosition, Quaternion.identity);
            _moneysPosition.Add(money.transform.position);
        }
        photonView.RPC("MapMoney", RpcTarget.AllBuffered, _moneysPosition.ToArray());
        
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
            SpawnMapMoney();
    }

    private void OnMoneyCollected(Vector3 position)
    {
        _moneysPosition.Remove(position);
    }

    private void SaveMapMoney(Vector3[] moneys)
    {
        _moneysPosition = new List<Vector3>(moneys);
    }

    private void SpawnMapMoney()
    {
        for (int i = 0; i < _moneysPosition.Count; i++)
        {
            GameObject money = PhotonNetwork.Instantiate(_moneyPrefab.name, _moneysPosition[i], Quaternion.identity);
        }
    }

    [PunRPC]
    private void MapMoney(Vector3[] moneysPosition)
    {
        SaveMapMoney(moneysPosition);
        _moneys = FindObjectsOfType<Money>();
        for (int i =0; i< _moneys.Length; i++)
        {
            _moneys[i].MoneyCollected += OnMoneyCollected;
        }
    }
}
