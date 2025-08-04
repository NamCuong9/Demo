using UnityEngine;
using Mirror;

public class NetworkCarController : NetworkBehaviour
{
    private PrometeoCarController prometeoCar;

    void Start()
    {
        prometeoCar = GetComponent<PrometeoCarController>();

        if (!isLocalPlayer)
        {
            prometeoCar.enabled = false;

            Camera cam = GetComponentInChildren<Camera>();
            if (cam != null)
            {
                cam.enabled = false;
                AudioListener al = cam.GetComponent<AudioListener>();
                if (al != null) al.enabled = false;
            }
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        // Màu ngẫu nhiên khác nhau mỗi xe
        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            rend.material.color = Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.7f, 1f);
        }
    }

    public override void OnStartLocalPlayer()
    {
        // Đánh dấu người chơi local bằng màu xanh lá
        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.green;
        }
    }
}
