using UnityEngine;

public class Bullet : MonoBehaviour
{
    private IAttack _owner;
    private float _damage;
    private Vector2 _direction;
    private float _speed = 3;

    public void Init(float damage, Vector2 direction, IAttack owner)
    {
        _owner = owner;
        _damage = damage;
        _direction = direction.normalized;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        gameObject.transform.position += (Vector3)(_direction * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<MapBorder>(out MapBorder mapBorder))
            Destroy(gameObject);

        if (collision.gameObject.TryGetComponent<IDamageble>(out IDamageble attacker))
            if (_owner != attacker)
            {
                attacker.TakeDamage(_damage);
                Destroy(gameObject);
            }
    }
}
