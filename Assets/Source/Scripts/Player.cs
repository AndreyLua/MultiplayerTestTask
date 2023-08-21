using UnityEngine;

public class Player : MonoBehaviour, IMoveble, IAttack, IDamageble
{
    [SerializeField] private PlayerSkinFactory _playerFactory;

    private Health _health;

    private HealthView _healthView;
    private PlayerView _playerView;

    private float _speed = 2;

    private float _damage = 3;
    private float _rate = 1;

    public float Speed => _speed;
    public float Damage => _damage;
    public float Rate => _rate;

    public Vector2 Direction =>gameObject.transform.rotation * Vector2.up;

    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
        _health.TakeDamage(damage);
    }

    private void Awake()
    {
        _playerView = gameObject.GetComponentInChildren<PlayerView>();
        _playerView.SetBodyView(_playerFactory.Create());

        _healthView = gameObject.GetComponentInChildren<HealthView>();

        _health = new Health(10,10);
        _health.Damaged += OnDamaged;
    }

    private void OnDamaged()
    {
        Debug.Log(_health.Value);
        _healthView.UpdateBar(_health);
    }
}
