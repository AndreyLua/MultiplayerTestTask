using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    private IMoveble _moveble;
    [SerializeField] private FixedJoystick _joystick;

    private void Awake()
    {
        _moveble = gameObject.GetComponent<IMoveble>();
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        Vector2 offset = _joystick.Direction * _moveble.Speed* Time.deltaTime;
        _moveble.transform.position += new Vector3(offset.x, offset.y, 0); 
    }

    private void RotatePlayer()
    {
        if (_joystick.Direction == Vector2.zero)
            return;

       Quaternion rotateQuart = Quaternion.Euler(0,0,-Mathf.Atan2(_joystick.Direction.x, _joystick.Direction.y)*180/Mathf.PI);
       _moveble.transform.rotation = rotateQuart;
    }
}
