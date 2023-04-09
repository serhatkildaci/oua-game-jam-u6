using UnityEngine;

public class DisableCameraRotation : MonoBehaviour
{
    public Camera orthoCamera;

    private void Update()
    {
        orthoCamera.transform.rotation = Quaternion.identity;
    }
}
