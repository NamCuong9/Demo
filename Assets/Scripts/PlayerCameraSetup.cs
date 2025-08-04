using UnityEngine;
using Mirror;
using Cinemachine;

public class PlayerCameraSetup : NetworkBehaviour
{
    [Header("Camera Rig Prefab")]
    public GameObject cameraRigPrefab;

    private GameObject cameraInstance;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        // Spawn camera rig
        cameraInstance = Instantiate(cameraRigPrefab);

        // Gán follow/lookAt cho FreeLook camera
        var freeLook = cameraInstance.GetComponentInChildren<CinemachineFreeLook>();
        if (freeLook != null)
        {
            freeLook.Follow = this.transform;
            freeLook.LookAt = this.transform;
        }

        // Set MainCamera tag
        var cam = cameraInstance.GetComponentInChildren<Camera>();
        if (cam != null)
        {
            cam.tag = "MainCamera";
        }
    }

    public override void OnStopLocalPlayer()
    {
        if (cameraInstance != null)
        {
            Destroy(cameraInstance);
        }
    }
}
