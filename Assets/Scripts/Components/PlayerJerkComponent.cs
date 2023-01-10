using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJerkComponent : MonoBehaviour, IAbility
{
    public Transform EmptyForDuraction;
    public Rigidbody PlayerRigidbody;
    public float JerkSpeed;
    public float JerkActionDelay = 1.5f;

    private float currentJerkTime = float.MinValue;

    public void Execute()
    {
        if (Time.time > currentJerkTime + JerkActionDelay)
        {
            currentJerkTime = Time.time;

            Vector3 duraction = (transform.position - EmptyForDuraction.transform.position).normalized;

            PlayerRigidbody.AddForce(duraction * JerkSpeed, ForceMode.Impulse);
        }
    }
}
