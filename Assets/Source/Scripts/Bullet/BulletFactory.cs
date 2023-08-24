using Photon.Pun;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    
    public Bullet Create(Vector2 startPosition, Vector2 direction, float damage, IAttack owner)
    {
        GameObject bulletPrefab = PhotonNetwork.Instantiate(_bulletPrefab.name, startPosition, Quaternion.identity);
        Bullet bullet = bulletPrefab.GetComponent<Bullet>();

        Quaternion rotateQuart = Quaternion.Euler(0, 0, -Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI);
        bullet.transform.rotation = rotateQuart;
        bullet.Init(damage, direction, owner);

        return bullet;
    }
}
