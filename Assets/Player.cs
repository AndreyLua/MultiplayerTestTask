using UnityEngine;

public class Player : MonoBehaviour, IMoveble, IAttack, IDamageble
{
    [SerializeField] private PlayerSkinFactory _playerFactory;

    private PlayerView _playerView;
    private float _speed = 2;
    private float _damage = 0.5f;
    private float _rate = 0.2f;

    public float Speed => _speed;
    public float Damage => _damage;
    public float Rate => _rate;

    public Vector2 Direction =>gameObject.transform.rotation * Vector2.up;

    public void TakeDamage(float damage)
    {
        Debug.Log("flkjdssjlkfdsj");
    }

    private void Awake()
    {
        _playerView = gameObject.GetComponentInChildren<PlayerView>();
        _playerView.SetBodyView(_playerFactory.Create());
    }

}
