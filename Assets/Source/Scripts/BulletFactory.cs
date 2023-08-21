using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    
    public Bullet Create(Vector2 startPosition, Vector2 direction, float damage)
    {
        Bullet bullet = Instantiate<Bullet>(_bulletPrefab);
        bullet.transform.position = startPosition;
        Quaternion rotateQuart = Quaternion.Euler(0, 0, -Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI);
        bullet.transform.rotation = rotateQuart;
        bullet.Init(damage, direction);
        return bullet;
    }
}
