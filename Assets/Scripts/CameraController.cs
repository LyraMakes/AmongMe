using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPos;
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);

        Vector3 distFromPlayer = smoothedPosition - desiredPosition;

        transform.position = (distFromPlayer.magnitude < 0.001) ? desiredPosition : smoothedPosition;
    }
}
