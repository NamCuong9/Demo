using UnityEngine;

public class GameQuit : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();

        // Nếu đang test trong Editor, thêm dòng sau để dừng play mode:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
