using UnityEngine;

public class PlayerSkinFactory : MonoBehaviour
{
    [SerializeField] private PlayerBodyViewsConfig _playerBodyViewsConfig;

    public PlayerBodyView Create()
    {
        int LengthBodyViews = _playerBodyViewsConfig.BodyViews.Length;
        int index = Random.Range(0, LengthBodyViews);
     
        return Create(index);
    }

    public PlayerBodyView Create(int index)
    {
        PlayerBodyView bodyView = _playerBodyViewsConfig.BodyViews[index];

        PlayerBodyView playerbodyView = Instantiate<PlayerBodyView>(bodyView);
        playerbodyView.NumberBodyView = index;

        return playerbodyView;
    }
}
