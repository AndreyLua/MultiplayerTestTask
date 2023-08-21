using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private PlayerBodyView _body;
    [SerializeField] private PlayerWeaponView _weapon;

    public PlayerBodyView Body => _body;
    public PlayerWeaponView Weapon => _weapon;

    public void SetBodyView(PlayerBodyView bodyView)
    {
        _body = bodyView;
    }
}


