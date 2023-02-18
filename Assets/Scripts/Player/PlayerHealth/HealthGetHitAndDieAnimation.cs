using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGetHitAndDieAnimation : MonoBehaviour
{
    [SerializeField] private string dieParameterName;
    [SerializeField] private string hitParameterName;
    private Animator animator;
    private Health health;

    private void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        health.TakeDamageEvent += GetHitAnimation;
        health.DeathEvent += DieAnimation;
    }

    public void GetHitAnimation()
    {
        animator.SetTrigger(hitParameterName);
    }

    public void DieAnimation()
    {
        animator.SetTrigger(dieParameterName);
    }
}
