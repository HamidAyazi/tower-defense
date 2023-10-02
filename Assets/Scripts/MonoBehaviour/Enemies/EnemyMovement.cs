using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private float Speed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = Speed = GetComponent<Enemy>().EnemySO.MovementSpeed;
        agent.SetDestination(SaveManager.Instance.Data.map.GoalPointPosition);
    }

    public void ChangeSpeed(float speed, float time)
    {
        agent.speed = speed;
        // Reset the speed back to the original value after 'time' seconds
        StartCoroutine(ResetSpeedAfterTime(time));
    }

    private IEnumerator ResetSpeedAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        agent.speed = Speed;
    }
}
