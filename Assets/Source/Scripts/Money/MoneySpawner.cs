using Photon.Pun;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Money _moneyPrefab;
    [SerializeField] private int _count;

    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnMoney();
        }
    }

    public void SpawnMoney()
    {
        Vector3 scale = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) ;

        for (int i = 0; i < _count; i++)
        {
            Vector3 startPosition = new Vector3(Random.Range(-scale.x, scale.x), Random.Range(-scale.y, scale.y), -1);
            GameObject money = PhotonNetwork.Instantiate(_moneyPrefab.name, startPosition, Quaternion.identity);
        }         
    }
}
