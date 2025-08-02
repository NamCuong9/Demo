using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartGameController : MonoBehaviour
{
    public GameObject menuPanel;        // UI Panel menu chứa nút Start
    public GameObject gameplayObjects;  // GameObject chứa xe, camera, v.v
    public RaceTimer raceTimer;
    private void Start()
    {
        // Bắt đầu thì chỉ hiện menu, ẩn gameplay
        if (menuPanel != null) menuPanel.SetActive(true);
        if (gameplayObjects != null) gameplayObjects.SetActive(false);
    }

    public void StartGame()
    {
        if (menuPanel != null) menuPanel.SetActive(false);
        if (gameplayObjects != null) gameplayObjects.SetActive(true);

        if (raceTimer != null)
        {
            raceTimer.StartTimer();
        }
        
    }

    


    public void QuitGame()
    {
        Debug.Log("Quitting game...");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Thoát Play Mode
#else
                Application.Quit(); // Thoát game khi build
#endif
    }

}


