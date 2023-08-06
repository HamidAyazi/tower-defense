using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float MovementSpeed;
    private Transform target;
    private int wavepointIndex = 0;

    void Start() {
        target = WaypointsScript.points[0];
        Debug.Log(target.position);
        MovementSpeed = Resources.Load<EnemyScriptableObject>("ScriptableObjects/Enemies/Enemy1").MovementSpeed;
    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * MovementSpeed * Time.deltaTime, Space.World);

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
