using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyScriptableObject Enemy;
    private Transform target;
    private int wavepointIndex = 0;

    void Start() {
        target = WaypointsScript.points[0];
        Enemy = Resources.Load<EnemyScriptableObject>("ScriptableObjects/Enemies/Enemy1");

    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Enemy.MovementSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f){
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {
        if(wavepointIndex >= WaypointsScript.points.Length - 1) {
            Destroy(gameObject);
        } else {
            wavepointIndex++;
            target = WaypointsScript.points[wavepointIndex];
        }
    }
}
