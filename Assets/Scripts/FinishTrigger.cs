using UnityEngine;
using Mirror;

public class FinishLineTrigger : NetworkBehaviour
{
    private bool raceEnded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (raceEnded) return;

        Debug.Log("Có đối tượng va chạm: " + other.name);

        NetworkIdentity identity = other.GetComponent<NetworkIdentity>();
        if (identity != null && identity.connectionToClient != null)
        {
            raceEnded = true;
            CmdPlayerReachedFinish(identity.connectionToClient.connectionId);
        }
    }

    [Command(requiresAuthority = false)]
    void CmdPlayerReachedFinish(int winnerConnectionId)
    {
        foreach (var kvp in NetworkServer.connections)
        {
            var conn = kvp.Value;
            string message = (kvp.Key == winnerConnectionId) ? "YOU WIN!" : "YOU LOSE!";
            TargetShowResult(conn, message);
        }
    }

    [TargetRpc]
    void TargetShowResult(NetworkConnection target, string message)
    {
        Debug.Log("🏁 TargetShowResult called with message: " + message);

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowResult(message);
        }
        else
        {
            Debug.LogWarning("⚠️ UIManager.Instance is NULL!");
        }
    }
}
