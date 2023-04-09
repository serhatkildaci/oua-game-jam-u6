using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float speed = 5f;

    private void Update()
    {
        Vector3 targetPosition = player.position + offset;
        Vector3 currentPosition = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        currentPosition.z = transform.position.z;
        transform.position = currentPosition;
    }
}
