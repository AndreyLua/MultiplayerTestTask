using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private IAttack _owner;
    private float _damage;
    private Vector2 _direction;
    private float _speed = 3;
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = gameObject.GetComponent<PhotonView>();
    }

    public void Init(float damage, Vector2 direction, IAttack owner)
    {
        _owner = owner;
        _damage = damage;
        _direction = direction.normalized;
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            Move();
        }
    }

    private void Move()
    {
        gameObject.transform.position += (Vector3)(_direction * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_photonView.IsMine)
        {
            if (collision.gameObject.TryGetComponent<MapBorder>(out MapBorder mapBorder))
            {
                PhotonView photonView = gameObject.GetComponent<PhotonView>();
                PhotonNetwork.Destroy(photonView);
            }

            if (collision.gameObject.TryGetComponent<IMultiplayerDamageble>(out IMultiplayerDamageble attacker))
            {
                if (_owner != attacker)
                {
                    PhotonView photonView = gameObject.GetComponent<PhotonView>();

                    photonView.RPC("TakeDamage",RpcTarget.Others, attacker.PhotonView.ViewID, _damage);
                    attacker.TakeDamage(_damage);
                    PhotonNetwork.Destroy(photonView);
                }
            }
        }
    }
    [PunRPC]
    private void TakeDamage(int idObject, float damage)
    {
        PhotonView photonView = PhotonView.Find(idObject);
        if (photonView != null && photonView.IsMine)
            photonView.GetComponent<IMultiplayerDamageble>().TakeDamage(damage);
    }
}
