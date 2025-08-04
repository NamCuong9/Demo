using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class NetworkUIManager : MonoBehaviour
{
    public GameObject menuUI; // Kéo menu UI vào đây từ Inspector

    public void StartHost()
    {
        Debug.Log("Start Host");
        if (!NetworkClient.active && !NetworkServer.active)
        {
            NetworkManager.singleton.StartHost();
            if (menuUI != null) menuUI.SetActive(false);
            AudioManager.Instance.PlayStartSound();
        }
    }

    public void StartClient()
    {
        if (!NetworkClient.active)
        {
            Debug.Log("Start Client");
            NetworkManager.singleton.StartClient();
            if (menuUI != null) menuUI.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Client already started.");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Nếu đang test trong editor
#endif
    }
}
