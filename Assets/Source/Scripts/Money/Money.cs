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
            Destroy(gameObject);
        }
    }
}
