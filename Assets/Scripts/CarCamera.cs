using UnityEngine;

public class FollowCarCamera : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform car; // Gán GameObject xe đua vào đây

    [Header("Camera Offset")]
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset theo local của xe

    [Header("Smooth Settings")]
    public float positionSmoothTime = 0.1f;
    public float rotationSmoothTime = 0.1f;

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        if (car == null) return;

        // Tính vị trí mong muốn theo local offset
        Vector3 desiredPosition = car.TransformPoint(offset);

        // Raycast để kiểm tra va chạm với terrain hoặc chướng ngại vật
        Vector3 directionToCamera = desiredPosition - car.position;
        float distance = directionToCamera.magnitude;
        Vector3 finalPosition = desiredPosition;

        if (Physics.Raycast(car.position, directionToCamera.normalized, out RaycastHit hit, distance))
        {
            // Camera bị che khuất, đặt nó ở gần hơn (tại điểm va chạm)
            finalPosition = hit.point - directionToCamera.normalized * 0.5f; // đẩy ra 0.5m tránh giật
        }

        // Mượt hoá chuyển động
        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref currentVelocity, positionSmoothTime);

        // Quay về xe đua (nhìn mượt)
        Quaternion targetRotation = Quaternion.LookRotation(car.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothTime);
    }
}
