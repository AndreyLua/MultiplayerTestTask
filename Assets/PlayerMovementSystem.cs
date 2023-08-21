using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour
{
    private Player _player;
    [SerializeField] private FixedJoystick _joystick;

    public void Init(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        Vector2 offset = _joystick.Direction * _player.Speed* Time.deltaTime;
        _player.transform.position += new Vector3(offset.x, offset.y, 0); 
    }

    private void RotatePlayer()
    {
        Quaternion rotateQuart = Quaternion.Euler(0,0,-Mathf.Atan2(_joystick.Direction.x, _joystick.Direction.y)*180/Mathf.PI);
        _player.transform.rotation = rotateQuart;
    }
   
}
