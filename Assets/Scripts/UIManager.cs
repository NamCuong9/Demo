using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI resultText;
    public GameObject resultPanel;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        resultPanel.SetActive(false); // Ẩn panel khi bắt đầu
    }

    public void ShowResult(string result)
    {
        resultPanel.SetActive(true);   // Bật panel
        resultText.text = result;      // Gán nội dung
    }
}
