using System.Collections;
using TMPro;  // Dùng nếu bạn dùng TextMeshPro
using UnityEngine;

public class CollisionUIManager : MonoBehaviour
{
    public TMP_Text collisionText;  // Nếu dùng UI Text thường thì đổi thành "public Text collisionText;"
    public float displayDuration = 2f;

    private Coroutine hideCoroutine;

    void Start()
    {
        if (collisionText != null)
            collisionText.gameObject.SetActive(false);  // Ẩn chữ khi bắt đầu
    }

    public void ShowCollisionText()
    {
        Debug.Log("Hiện chữ va chạm!");
        if (collisionText == null) return;

        collisionText.text = "Collide !";
        collisionText.gameObject.SetActive(true);

        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);

        hideCoroutine = StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        collisionText.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra nếu va chạm với đối tượng cụ thể
        if (collision.gameObject.CompareTag("YourTag")) // Thay "YourTag" bằng tag của đối tượng bạn muốn va chạm
        {
            ShowCollisionText();
        }
    }
}
