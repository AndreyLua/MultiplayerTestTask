using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerView _playerView;

    public PlayerView PlayerView => _playerView;

    private void Awake()
    {
        _playerView = gameObject.GetComponentInChildren<PlayerView>();
    }

}
