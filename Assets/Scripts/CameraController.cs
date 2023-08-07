using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 20.0f;

    void Update() {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = touch.deltaPosition;
                horizontalMovement = touchDeltaPosition.x;
                verticalMovement = touchDeltaPosition.y;
            }
        }
        
        Vector3 moveDirection = new Vector3(horizontalMovement, verticalMovement, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
