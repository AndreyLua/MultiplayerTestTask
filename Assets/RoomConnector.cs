using Photon.Pun;
using System;
using UnityEngine;

public class RoomConnector : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMPInputField _inputField;
    [SerializeField] private TMPButton _button;

    private string _nameRoom;

    public event Action JoinedInRoom;

    private void Awake()
    {
        _inputField.InputStringChanged += OnNameOfRoomChanged;
        _button.Clicked += JoinRoom;

    }

    private void OnNameOfRoomChanged(string name)
    {
        _nameRoom = name;
    }

    private void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_nameRoom);
    }

    public override void OnJoinedRoom()
    {
        JoinedInRoom?.Invoke();
    }
}
