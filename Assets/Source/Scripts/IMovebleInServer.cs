using Photon.Pun;

public interface IMovebleInServer : IMoveble
{
    public PhotonView PhotonView { get; }
}
