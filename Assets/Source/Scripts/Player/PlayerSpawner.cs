using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private MoneyStorage _moneyStorage;

    [SerializeField] private BulletFactory _bulletFactory;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private TMPButton _fireButton;

    [SerializeField] private PlayerSkinFactory _playerSkinFactory;
    [SerializeField] private LocalPlayer _playerPrefab;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Vector3 scaleScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Vector3 startPosition = new Vector3(Random.Range(-scaleScreen.x, scaleScreen.x), Random.Range(-scaleScreen.y, scaleScreen.y), 0);

        GameObject player = (GameObject)PhotonNetwork.Instantiate(_playerPrefab.name, startPosition, Quaternion.identity);

        PlayerBuilder builder = new PlayerBuilder(_moneyStorage, _playerSkinFactory.Create());

        player.GetComponent<LocalPlayer>().Init(builder);

        player.GetComponent<PlayerAttack>().Init(_fireButton, _bulletFactory);
    }
}

public class PlayerBuilder
{
    public MoneyStorage MoneyStorage;
    public PlayerBodyView PlayerBodyView;

    public PlayerBuilder(MoneyStorage moneyStorage, PlayerBodyView playerBodyView)
    {
        MoneyStorage = moneyStorage;
        PlayerBodyView = playerBodyView;
    }
}