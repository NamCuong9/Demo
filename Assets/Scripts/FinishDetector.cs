using UnityEngine;
using TMPro;

public class FinishDetector : MonoBehaviour
{
    public RaceTimer raceTimer;
    public TextMeshProUGUI winText;

    private bool hasFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Va chạm với: " + other.name);  // <- thêm dòng này để kiểm tra

        if (other.CompareTag("Finish"))
        {
            Debug.Log("ĐẾN ĐÍCH!");  // <- dòng này phải hiện ra nếu đúng tag
            if (hasFinished) return;

            if (other.CompareTag("Finish"))
            {
                hasFinished = true;

                if (raceTimer != null)
                    raceTimer.StopTimer();

                if (winText != null)
                {
                    winText.text = "🏁 YOU WIN! 🏁";
                    winText.gameObject.SetActive(true);
                }

                Debug.Log("Đã đến đích!");
            }
        }
    }
}
