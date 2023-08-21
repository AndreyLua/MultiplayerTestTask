using System;

public class Health
{
    private float _maxValue;
    private float _value;

    public event Action Died;
    public event Action Damaged;

    public float Value => _value;
    public float MaxValue => _maxValue;


    public Health(float value, float maxValue)
    {
        _maxValue = maxValue;
        _value = value;
    }

    public void SetMaxValue(float maxValue)
    {
        if (maxValue <= 0)
            throw new Exception("Health maxvalue cant be negative");
        _maxValue = maxValue;
    }
    public void TakeDamage(float damageValue)
    {
        if (damageValue < 0)
            throw new Exception("Damage cant be negative");

        _value -= damageValue;
        Damaged?.Invoke();

        if (_value <= 0)
            Died?.Invoke();
    }

    public void Heal(float healValue)
    {
        if (healValue < 0)
            throw new Exception("Heal cant be negative");

        _value += healValue;

        if (_value > _maxValue)
            _value = _maxValue;
    }
}