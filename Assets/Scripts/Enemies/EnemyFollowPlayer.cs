using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour, IEnemy
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float followDistance;
    private NavMeshAgent meshAgent;

    private void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    public float Evaluate()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < followDistance)
        {
            return 0.3f;
        }
        else
        {
            return 0;
        }
    }

    public void Perform()
    {
        meshAgent.destination = playerTransform.position;
    }
}
