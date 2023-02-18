using DG.Tweening;
using Photon.Pun;
using UnityEngine;

public class TrapAttack : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitPS;
    [SerializeField] private Vector3 endScale;
    [SerializeField] private float animDuraction;
    [SerializeField] private float damageScale;
    private Vector3 startScale;

    private void Start()
    {
        startScale = transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            if(collision.gameObject.TryGetComponent(out PhotonView photonView) && photonView.IsMine)
            {
                health.TakeDamage(Vector3.Magnitude(collision.impulse));
            }

            hitPS.transform.position = collision.GetContact(0).point;
            hitPS.transform.rotation = Quaternion.LookRotation(collision.impulse * damageScale);
            hitPS.Play();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(endScale, animDuraction));
            sequence.Append(transform.DOScale(startScale, animDuraction));
        }
    }
}
