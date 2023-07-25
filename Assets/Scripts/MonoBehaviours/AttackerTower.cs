using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerTower : MonoBehaviour
{
    private Transform TargetTransform;
    private float LookForTargetTimer;
    private float LookForTargetTimerMAX = .2f;
    private float Range;

    // Start is called before the first frame update
    void Start()
    {
        Range = GetComponent<AttackerTowerScriptableObject>().BaseRange;
        Debug.Log(Range);
    }

    // Update is called once per frame
    void Update()
    {
        HandleTargeting();
    } 
    private void HandleTargeting()
    {
        LookForTargetTimer -= Time.deltaTime;
        if (LookForTargetTimer < 0f)
        {
            LookForTargetTimer += LookForTargetTimerMAX;
            LookForTargets();
        }
    }
    private void LookForTargets()
    {
        Collider2D[] Collider2DArray = Physics2D.OverlapCircleAll(transform.position, Range);

        foreach(Collider2D Collider2D in Collider2DArray)
        {
            Enemy enemy = Collider2D.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Is a building!
                if(TargetTransform == null)
                {
                    TargetTransform = enemy.transform;
                } else
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) < 
                        Vector3.Distance(transform.position, TargetTransform.position))
                    {
                        TargetTransform = enemy.transform;
                    }
                }
            }
        }
    }
}
