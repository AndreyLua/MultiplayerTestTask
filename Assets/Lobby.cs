using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    [SerializeField] private RoomConnector _roomConnector;

    private void Awake()
    {
        _roomConnector.JoinedInRoom += OnRoomJoined;
    }

    private void OnRoomJoined()
    {
        SceneManager.LoadScene(1);
    }
}
