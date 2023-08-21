using DG.Tweening;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private TMPButton _button;
    [SerializeField] private BulletFactory _bulletFactory;

    private IAttack _attack;
    private bool _canAttack = true;

    private void Awake()
    {
        _attack = gameObject.GetComponent<IAttack>();
        _button.Clicked += Attack;
    }

    private void Attack()
    {
        if (_canAttack)
        {
            _canAttack = false;
            _bulletFactory.Create(gameObject.transform.position, _attack.Direction, _attack.Damage, _attack);
            DOTween.Sequence().AppendInterval(_attack.Rate).AppendCallback(() => _canAttack = true);
        }
    }
}
