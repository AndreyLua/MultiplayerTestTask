using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _bar;

    public void UpdateBar(Health health)
    {
        float healthRatio = health.Value / health.MaxValue;
        _bar.transform.localScale = new Vector3(healthRatio, transform.localScale.y, transform.localScale.z);
    }
}
