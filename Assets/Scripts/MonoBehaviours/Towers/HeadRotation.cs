using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    private Enemy TargetEnemy;
    private Vector3 Direction;
    private float RotationSpeed = 60f;

    // Update is called once per frame
    void Update()
    {
        TargetEnemy = transform.parent.GetComponent<AttackerTower>().TargetEnemy;
        if (TargetEnemy != null)
        {
            Vector3 Direction = TargetEnemy.transform.position - transform.position;
            float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, 0f, Angle - 90f); // Offset by -90 degrees

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }

    }
}