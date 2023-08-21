using UnityEngine;
using TMPro;

public class MoneyStorageView : MonoBehaviour
{
    [SerializeField] private MoneyStorage _moneyStorage;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = gameObject.GetComponent<TextMeshProUGUI>();
        _moneyStorage.UpdateMoneView += UpdateValue;
    }

    private void UpdateValue(int value)
    {
        _text.text = value.ToString();
    }
}
