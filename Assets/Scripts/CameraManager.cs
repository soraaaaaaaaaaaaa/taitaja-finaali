using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTarget;
    [SerializeField]
    private float smoothTime = 0.1f;
    private Vector3 cameraPositionSpeed;
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - cameraTarget.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var cameraTargetPosition = cameraTarget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, cameraTargetPosition, ref cameraPositionSpeed, smoothTime);
    }
}
