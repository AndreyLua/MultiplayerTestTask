using System;
using UnityEngine;

public class MoneyStorage : MonoBehaviour
{
    private int _money;

    public event Action<int> UpdateMoneView;
    
    public void Add(int value)
    {
        if (value < 0)
            throw new Exception("Money cant be negative");
        _money += value;
        UpdateMoneView?.Invoke(_money);
    }

    public bool TryBuy(int value)
    {   
        bool IsBuy = value <= _money;
        if (IsBuy)
        {
            _money -= value;
            UpdateMoneView?.Invoke(_money);
        }

        return IsBuy;
    }
}
