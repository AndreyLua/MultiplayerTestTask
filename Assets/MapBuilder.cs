using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    [SerializeField] private MapTile _mapTile;

    [SerializeField] private float _sizeTile;

    private void Awake()
    {
        Vector3 scale  = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height))*2;

        for (int i=0; i< (int)(scale.x/_sizeTile); i++)
        {
            for (int j = 0; j < (int)(scale.y / _sizeTile)+1; j++)
            {
                MapTile newTile = Instantiate<MapTile>(_mapTile);

                newTile.transform.parent = gameObject.transform;

                Vector2 newTileSize = newTile.SpriteRenderer.bounds.size;

                float scaleFactor = (scale.x / newTileSize.x) / (int)(scale.x / _sizeTile);

                newTile.transform.localScale = newTile.transform.localScale * scaleFactor;

                newTileSize *= scaleFactor;

                Vector2 startPosition = (Vector2)gameObject.transform.position - new Vector2(-newTileSize.x / 2, newTileSize.y / 2);

                Vector2 offset = new Vector2(i * newTile.SpriteRenderer.bounds.size.x, -j * newTile.SpriteRenderer.bounds.size.y);

                newTile.transform.position = startPosition + offset;
            }
        }
    }
}
