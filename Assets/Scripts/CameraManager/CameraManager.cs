using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{  

    public float dampTime = 0.2f;
    public float screenEdgeBuffer = 6f;
    public float MinSize = 6.5f;
    float zoomDistance;
    public float ZoomOffset = 3; 

    Camera camera;
    float ZoomSpeed = 0.2f;
    Vector2 MoveVelocity;
    Vector2 DesiredPosition;
    float ZoomVelocity;
    Vector2 StartPosition;
    float DefaultCamZoom;

    private void Awake()
    {
        camera = GetComponentInChildren<Camera>();
        StartPosition = this.transform.position;
        MoveCameraToStartPositionAndSize();
        DefaultCamZoom = camera.orthographicSize;

    }

    public void AssignTarget(Vector2 targetTransform) 
    {
        DesiredPosition = targetTransform;
    }

    public void SetZoomDistance(float desiredZoomDistance)
    {
        zoomDistance = desiredZoomDistance * ZoomOffset;
    }

    private void Update()
    {
        AdjustZoom();
        Move();  
    }

    private void Move()
    {
        transform.position = Vector2.SmoothDamp(transform.position, DesiredPosition, ref MoveVelocity, dampTime);
    }

    private void AdjustZoom()
    {
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, zoomDistance, ref ZoomVelocity, ZoomSpeed);
    }

    public void MoveCameraToStartPositionAndSize()
    {
        DesiredPosition = StartPosition;
        zoomDistance = DefaultCamZoom;
    }

}