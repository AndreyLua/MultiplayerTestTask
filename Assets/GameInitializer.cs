using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private PlayerFactory _playerFactory;
    [SerializeField] private PlayerMovementSystem _playerMovementSystem;

    private void Awake()
    {
        Player player = _playerFactory.CreateWithRandomBody(new Vector2(0,0));
        _playerMovementSystem.Init(player);
    }
}
