using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public AudioSource engineAudioSource;  // <-- gán thủ công trong Inspector

    public float pitchMultiplier = 0.01f;
    public float maxPitch = 3f;

    void Start()
    {
        if (engineAudioSource != null)
        {
            engineAudioSource.loop = true;
            engineAudioSource.Play();
        }
        else
        {
            Debug.LogError("Engine Audio Source is not assigned!");
        }
    }

    void Update()
    {
        if (engineAudioSource == null || carRigidbody == null) return;

        float speed = carRigidbody.velocity.magnitude;
        engineAudioSource.pitch = Mathf.Clamp(1f + speed * pitchMultiplier, 1f, maxPitch);
    }
}
