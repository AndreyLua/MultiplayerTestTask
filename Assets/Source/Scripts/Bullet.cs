using UnityEngine;

public class Bullet : MonoBehaviour, IMoveble
{
    private float _damage;
    private Vector2 _direction;
    private float _speed = 3;

    public float Speed => _speed;

    public void Init(float damage, Vector2 direction)
    {
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
        if (collision.gameObject.TryGetComponent<IDamageble>(out IDamageble enemy))
            enemy.TakeDamage(_damage);
    }
}
