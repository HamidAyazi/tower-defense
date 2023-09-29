using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = GetComponent<Enemy>().EnemySO.MovementSpeed;
        agent.SetDestination(SaveManager.Instance.Data.map.GoalPointPosition);
    }
}
