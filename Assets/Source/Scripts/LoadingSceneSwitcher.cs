using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneSwitcher : MonoBehaviour
{
    [SerializeField] private PhotonServerConnector _serverConnector;

    private void Awake()
    {
        _serverConnector.ConnectedToMascter += SwitchScene;
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(2);
    }
}
