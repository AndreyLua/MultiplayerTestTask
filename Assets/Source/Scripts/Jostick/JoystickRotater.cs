using Photon.Pun;
using UnityEngine;

public class JoystickRotater : MonoBehaviour
{
    private Joystick _joystick;
    private PhotonView _photonView;

    private void Awake()
    {
        _joystick = FindObjectOfType<Joystick>();
        _photonView = gameObject.GetComponentInParent<PhotonView>();
    }

    private void Update()
    {
        if (_photonView.IsMine && _joystick!= null)
            RotatePlayer();
    }

    private void RotatePlayer()
    {
        if (_joystick.Direction == Vector2.zero)
            return;

        Quaternion rotateQuart = Quaternion.Euler(0, 0, -Mathf.Atan2(_joystick.Direction.x, _joystick.Direction.y) * 180 / Mathf.PI);
        gameObject.transform.rotation = rotateQuart;
    }
}