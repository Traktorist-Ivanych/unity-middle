using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour, IEnemy
{
    [SerializeField] private Rigidbody bulletRigidbody;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform bulletStartTrasform;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float rechargeTime;
    [SerializeField] private float attackDistance;
    private Rigidbody enemyRigidbody;
    private float currentRechargeTime = float.MinValue;

    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    public float Evaluate()
    {
        if (currentRechargeTime + rechargeTime < Time.time &&
            Vector3.Distance(transform.position, playerTransform.position) < attackDistance)
        {
            currentRechargeTime = Time.time;
            return 0.5f;
        }
        else
        {
            return 0;
        }
    }

    public void Perform()
    {
        bulletRigidbody.velocity = Vector3.zero;
        bulletRigidbody.angularVelocity = Vector3.zero;
        bulletRigidbody.transform.position = bulletStartTrasform.position;

        Vector3 playerTarget = new Vector3(playerTransform.position.x, playerTransform.position.y + 1.5f, 
                                           playerTransform.position.z);
        Vector3 duraction = (playerTarget - bulletStartTrasform.position).normalized;
        bulletRigidbody.AddForce(duraction * bulletSpeed + enemyRigidbody.velocity, ForceMode.Impulse);
    }
}
