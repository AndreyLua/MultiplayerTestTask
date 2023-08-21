using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBodyViewsConfig", menuName = "Player/new PlayerBodyViewsConfig")]

public class PlayerBodyViewsConfig : ScriptableObject
{
    [SerializeField] private PlayerBodyView[] _bodyViews;
    public PlayerBodyView[] BodyViews => _bodyViews;
}