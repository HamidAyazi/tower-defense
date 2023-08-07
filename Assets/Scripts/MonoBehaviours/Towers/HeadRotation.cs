using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    Enemy TargetEnemy;
    Vector3 Direction;

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
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(Direction));
        }

    }
    private float GetAngleFromVector(Vector3 Vector)
    {
        float Radians = Mathf.Atan2(Vector.y, Vector.x);
        float Degrees = Radians * Mathf.Rad2Deg;
        return Degrees;
    }
}