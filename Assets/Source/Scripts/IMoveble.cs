using UnityEngine;

public interface IMoveble
{
    public float Speed { get; }
    public Rigidbody2D Rigidbody { get; }
}
