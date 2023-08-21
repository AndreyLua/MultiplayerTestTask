using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerView _playerView;

    private float _speed = 2;

    public float Speed => _speed;

    public PlayerView PlayerView => _playerView;

    private void Awake()
    {
        _playerView = gameObject.GetComponentInChildren<PlayerView>();
    }

}
