using UnityEngine;

public interface IAttack
{
    public float Damage { get; }
    public float Rate { get; }
    public Vector2 Direction { get; }
}