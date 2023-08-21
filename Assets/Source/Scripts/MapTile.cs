using UnityEngine;

public class MapTile : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public Sprite Sprite => SpriteRenderer.sprite;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
}
