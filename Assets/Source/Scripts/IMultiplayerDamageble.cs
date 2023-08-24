using Photon.Pun;

public interface IMultiplayerDamageble
{
    void TakeDamage(float damage);
    public PhotonView PhotonView { get; }
}