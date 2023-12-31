using Photon.Pun;
using UnityEngine;

public class LocalPlayer : MonoBehaviour, IMultiplayerMoveble, IAttack, IMultiplayerDamageble, ICollector
{
    private Rigidbody2D _rigidbody;
    private PhotonView _photonView;

    private MoneyStorage _moneyStorage;
    private Health _health;
   
    private HealthView _healthView;
    private PlayerView _playerView;

    private float _speed = 2;

    private float _damage = 3;
    private float _rate = 1;

    public float Speed => _speed;
    public float Damage => _damage;
    public float Rate => _rate;

    public Vector2 Direction => _playerView.transform.rotation * Vector2.up;
    public Rigidbody2D Rigidbody => _rigidbody;

    public PhotonView PhotonView => _photonView;

    private void Awake()
    {
        _photonView = gameObject.GetComponent<PhotonView>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _playerView = gameObject.GetComponentInChildren<PlayerView>();
        _healthView = gameObject.GetComponentInChildren<HealthView>();

        _health = new Health(10,10);
        _health.Damaged += OnDamaged;
        _health.Died += OnDied;
    }

    public void Init(PlayerBuilder playerBuilder)
    {
        _playerView.SetBodyView(playerBuilder.PlayerBodyView);
        _moneyStorage = playerBuilder.MoneyStorage;

        if (_photonView.IsMine)
            _photonView.RPC("InitBodyView", RpcTarget.OthersBuffered, playerBuilder.PlayerBodyView.NumberBodyView);
    }

    private void OnDamaged()
    {
        _healthView.UpdateBar(_health);
    }

    private void OnDied()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    public void TakeMoney(int value)
    {
        _moneyStorage.Add(value);
    }

    [PunRPC]
    private void InitBodyView(int index)
    {
        PlayerSkinFactory playerSkinFactory = FindObjectOfType<PlayerSkinFactory>();
        _playerView.SetBodyView(playerSkinFactory.Create(index));
    }

}
