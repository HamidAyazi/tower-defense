using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HeadRotation : MonoBehaviour
{
    private Enemy TargetEnemy;
    private float RotationSpeed;
    private float Angle;
    private Vector3 Direction;

    // Update is called once per frame
    private void Update()
    {
        if (TargetEnemy != null)
        {
            Direction = TargetEnemy.transform.position - transform.position;
            Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, 0f, Angle - 90f); // Offset by -90 degrees

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }

    }
    
    /// <summary>
    /// Check if <c>Tower</c> is locked on a target or not.
    /// </summary>
    /// <returns>True if <c>Tower</c> is looking at <c>TargetEnemy</c>, elsewise False.</returns>
    public bool IsLocked()
    {
        // Ensure the angle is positive and within 0 to 180 degrees range
        Angle = (Angle + 360f) % 360f;

        // Calculate the difference between the angle to the enemy and the tower's current rotation
        float AngleDifference = Mathf.Abs(Angle - transform.eulerAngles.z);

        // Calculate the minimum angle difference (considering wrapping around 360 degrees)
        float MinAngleDifference = Mathf.Min(AngleDifference, 360f - AngleDifference);

        // Check if the tower's angle difference is within the angle threshold
        return MinAngleDifference <= 95f && MinAngleDifference >= 85f;
    }

    /// <summary>
    /// Set target for tower's head to be locked on.
    /// </summary>
    /// <param name="TargetEnemy">Target to be locked on.</param>
    public void SetTarget(Enemy TargetEnemy)
    {
        this.TargetEnemy = TargetEnemy;
    }

    /// <summary>
    /// Set head's rotation speed.
    /// </summary>
    /// <param name="RotationSpeed">Speed in degrees per second.</param>
    public void SetRotationSpeed(float RotationSpeed)
    {
        this.RotationSpeed = RotationSpeed;
    }
}