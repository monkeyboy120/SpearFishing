using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target that the camera follows
    public float smoothTime = 0.3f; // Time for the camera to reach the target
    public float cameraZ;

    private Vector3 velocity = Vector3.zero; // Velocity reference, used by SmoothDamp

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;

            // Modify the target position as needed (e.g., add offset, limit to certain axes, etc.)
            targetPosition.z = cameraZ;

            // Smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}