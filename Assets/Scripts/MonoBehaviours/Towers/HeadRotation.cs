using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    private Enemy TargetEnemy;
    private Vector3 Direction;
    private float RotationSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TargetEnemy = transform.parent.GetComponent<AttackerTower>().TargetEnemy;
        if (TargetEnemy != null)
        {
            Direction = (TargetEnemy.transform.position - transform.position).normalized;
            Quaternion Rotation = Quaternion.Euler(0f, 0f, GetAngleFromVector(Direction));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, RotationSpeed * Time.deltaTime);
        }

    }
    private float GetAngleFromVector(Vector3 Vector)
    {
        float Radians = Mathf.Atan2(Vector.y, Vector.x);
        float Degrees = Radians * Mathf.Rad2Deg;
        return Degrees;
    }
}