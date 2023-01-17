using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAttack : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitPS;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(Vector3.Magnitude(collision.impulse));

            hitPS.transform.position = collision.GetContact(0).point;
            hitPS.transform.rotation = Quaternion.LookRotation(collision.impulse);
            hitPS.Play();
        }
    }
}
