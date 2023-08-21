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
    }

    private void MovePlayer()
    {
        Vector2 offset = _joystick.Direction * _moveble.Speed* Time.deltaTime;
        _moveble.transform.position += new Vector3(offset.x, offset.y, 0); 
    }
}
