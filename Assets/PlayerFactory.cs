using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private PlayerBodyViewsConfig _playerBodyViewsConfig;

    public Player CreateWithRandomBody(Vector2 position)
    {
        int LengthBodyViews = _playerBodyViewsConfig.BodyViews.Length;
        PlayerBodyView bodyView = _playerBodyViewsConfig.BodyViews[Random.Range(0, LengthBodyViews)];

        return Create(position, bodyView);
    }

    public Player Create(Vector2 position, PlayerBodyView bodyView)
    {
        Player player = Instantiate<Player>(_playerPrefab);
        PlayerBodyView playerbodyView = Instantiate<PlayerBodyView>(bodyView);
        player.PlayerView.SetBodyView(playerbodyView);
        player.transform.position = position;
        return player;
    }
}
