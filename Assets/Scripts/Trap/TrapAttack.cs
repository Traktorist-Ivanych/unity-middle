using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapAttack : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitPS;
    [SerializeField] private Vector3 endScale;
    [SerializeField] private float animDuraction;
    private Vector3 startScale;

    private void Start()
    {
        startScale = transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(Vector3.Magnitude(collision.impulse));

            hitPS.transform.position = collision.GetContact(0).point;
            hitPS.transform.rotation = Quaternion.LookRotation(collision.impulse);
            hitPS.Play();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(endScale, animDuraction));
            sequence.Append(transform.DOScale(startScale, animDuraction));
        }
    }
}
