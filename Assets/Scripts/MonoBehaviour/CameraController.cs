using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private int targetFrameRate; // Adjust the frame rate.
    [SerializeField] private float panSpeed; // Adjust the camera pan speed.
    [SerializeField] private float smoothness; // Adjust the smoothness of camera movement.
    [SerializeField] private Vector2 panLimit ; // Set the limit for camera panning.

    private Vector3 targetPosition;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        // Initialize the target position to the camera's starting position.
        targetPosition = transform.position;

    }
    private void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            Vector3 touchDeltaPosition = touch.deltaPosition;
            Vector3 panDirection = new Vector3(-touchDeltaPosition.x, -touchDeltaPosition.y, 0) * panSpeed * Time.deltaTime;
            targetPosition += panDirection;

            // Apply camera position limits.
            targetPosition.x = Mathf.Clamp(targetPosition.x, -panLimit.x, panLimit.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -panLimit.y, panLimit.y);
        }
    }
    private void LateUpdate()
    {
        // Smoothly move the camera towards the target position.
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
    }
}
