using UnityEngine;

public class PlayerSkinFactory : MonoBehaviour
{
    [SerializeField] private PlayerBodyViewsConfig _playerBodyViewsConfig;

    public PlayerBodyView Create()
    {
        int LengthBodyViews = _playerBodyViewsConfig.BodyViews.Length;
        PlayerBodyView bodyView = _playerBodyViewsConfig.BodyViews[Random.Range(0, LengthBodyViews)];
        PlayerBodyView playerbodyView = Instantiate<PlayerBodyView>(bodyView);

        return playerbodyView;
    }
}
