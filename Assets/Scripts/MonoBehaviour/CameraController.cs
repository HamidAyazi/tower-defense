using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed; // Adjust the camera pan speed.
    [SerializeField] private float smoothness; // Adjust the smoothness of camera movement.
    [SerializeField] private Vector2 panLimit ; // Set the limit for camera panning.

    private Vector3 targetPosition;
    private bool isTouching = false;

    private void Start()
    {
        // Initialize the target position to the camera's starting position.
        targetPosition = transform.position;

    }
    private void Update()
    {
        if (Input.touchCount != 0)
        {
            HandleTouchInput();
        }
    }

    private void HandleTouchInput()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            // Set the isTouching flag when a new touch begins.
            isTouching = true;
        }

        if (isTouching && touch.phase == TouchPhase.Moved)
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
        // Smoothly move the camera towards the target position only if there's touch input.
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
    }
}
