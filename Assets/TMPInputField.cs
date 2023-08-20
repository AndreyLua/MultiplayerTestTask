using System;
using TMPro;
using UnityEngine;

public class TMPInputField : MonoBehaviour
{
    private TMP_InputField _inputField;

    public event Action<string> InputStringChanged;

    private void Awake()
    {
        _inputField = gameObject.GetComponent<TMP_InputField>();
        _inputField.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(string text)
    {
        InputStringChanged?.Invoke(text);
    }
}
