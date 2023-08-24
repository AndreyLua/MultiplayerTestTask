using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    private IMovebleInServer _moveble;
    private Joystick _joystick;

    private void Awake()
    {
        _joystick = FindObjectOfType<Joystick>();
        _moveble = gameObject.GetComponent<IMovebleInServer>();
    }

    private void Update()
    {
        if (_moveble.PhotonView.IsMine)
            MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 offset = _joystick.Direction * _moveble.Speed* Time.deltaTime;
        _moveble.Rigidbody.transform.position += new Vector3(offset.x, offset.y, 0); 
    }
}
