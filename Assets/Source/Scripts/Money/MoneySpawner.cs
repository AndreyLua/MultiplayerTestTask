using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Money _moneyPrefab;
    [SerializeField] private int _count;

    private void Awake()
    {
        Vector3 scale = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) ;

        for (int i = 0; i < _count; i++)
        {
            Money money = Instantiate<Money>(_moneyPrefab, gameObject.transform);
            money.transform.position = new Vector3(Random.Range(-scale.x, scale.x), Random.Range(-scale.y, scale.y),0);
        }         
    }
}
