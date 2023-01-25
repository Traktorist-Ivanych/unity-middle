using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour, IEnemy
{
    [SerializeField] private Transform[] targetsTransforms;
    private NavMeshAgent navAgent;
    private int currentTarget;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        ChoiceTarget();
    }

    public float Evaluate()
    {
        return 0.1f;
    }

    public void Perform()
    {
        if (Vector3.Distance(transform.position, navAgent.destination) < 0.5f)
        {
            ChoiceTarget();
        }
    }

    private void ChoiceTarget()
    {
        currentTarget = Random.Range(0, targetsTransforms.Length - 1);
        navAgent.destination = targetsTransforms[currentTarget].position;
    }
}
