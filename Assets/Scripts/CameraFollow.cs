using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private float x;
    private float y;
    private float z;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        x = Mathf.Clamp(smoothedPosition.x, minX, maxX);
        y = Mathf.Clamp(smoothedPosition.y, minY, maxY);
        z = smoothedPosition.z;

        transform.position = new Vector3(x, y, z);
    }
}