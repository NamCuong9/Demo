using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public CollisionUIManager uiManager;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Đã va chạm với: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("ObstacleCar"))
        {
            Debug.Log("Va chạm với xe chướng ngại vật!");
            if (uiManager != null)
            {
                uiManager.ShowCollisionText();
            }
            else
            {
                Debug.LogWarning("UI Manager chưa được gán!");
            }
        }
    }
}
