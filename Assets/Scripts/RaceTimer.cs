using UnityEngine;
using TMPro;

public class RaceTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float elapsedTime = 0f;
    private bool isTiming = false;

    public void StartTimer()
    {
        elapsedTime = 0f;
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
    }

    public float GetFinalTime()
    {
        return elapsedTime;
    }

    void Update()
    {
        if (isTiming)
        {
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000);

            timerText.text = $"{minutes:00}:{seconds:00}.{milliseconds:000}";
        }
    }
}
