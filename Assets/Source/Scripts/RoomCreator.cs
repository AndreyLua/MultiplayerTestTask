using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomCreator : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMPInputField _inputField;
    [SerializeField] private TMPButton _button;

    [SerializeField] private int _maxPlayersInOneRoom = 4;

    private RoomOptions _roomOptions;

    private string _nameRoom;

    private void Awake()
    {
        _roomOptions = new RoomOptions();
        _roomOptions.MaxPlayers = _maxPlayersInOneRoom;

        _inputField.InputStringChanged += OnNameOfRoomChanged;
        _button.Clicked += CreateRoom;

    }

    private void OnNameOfRoomChanged(string name)
    {
        _nameRoom = name;
    }

    private void CreateRoom()
    {
        PhotonNetwork.CreateRoom(_nameRoom, _roomOptions);
    }

}
