using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Transform _localLeftPosition;
    [SerializeField] private GameObject _bar;

    public void UpdateBar(float value, float maxValue)
    {
        Vector3 newPosition = _localLeftPosition.position + new Vector3(0.19f, 0, 0) * value / maxValue;

        _bar.transform.localScale = new Vector3(value / maxValue, transform.localScale.y, transform.localScale.z);
        _bar.transform.position = new Vector3(newPosition.x, _bar.transform.position.y, _bar.transform.position.z);
    }
}
