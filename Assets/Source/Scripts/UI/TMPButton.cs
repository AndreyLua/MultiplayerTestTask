using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TMPButton : MonoBehaviour
{
    private Button _screenButton;
    private TextMeshProUGUI _text;

    public string Text => _text.text;

    public event Action Clicked;

    private void Awake()
    {
        _text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        _screenButton = gameObject.GetComponent<Button>();
        _screenButton.onClick.AddListener(OnClick);
    }

    protected virtual void OnClick()
    {
        Clicked?.Invoke();
    }
}
