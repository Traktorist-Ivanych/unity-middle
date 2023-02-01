using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : PlayerInputActionPossibility, IInputAbility
{
    [SerializeField] private TrailRenderer swordTrail;
    [SerializeField] private Rigidbody bulletRigidbody;
    [SerializeField] private Transform transformForDuraction;
    [SerializeField] private Transform bulletStartTransform;
    [SerializeField] private float bulletSpeed;

    private Animator playerAnimator;
    private Rigidbody playerRigidbody;
    private string attackParameterName = "Attack";

    private protected override void OnStart()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        if (CanActionExecute)
        {
            playerAnimator.SetTrigger(attackParameterName);

            StartCoroutine(ThrowBullet());
        }
    }

    private IEnumerator ThrowBullet()
    {
        yield return new WaitForSeconds(0.4f);
        bulletRigidbody.velocity = Vector3.zero;
        bulletRigidbody.angularVelocity = Vector3.zero;
        bulletRigidbody.transform.SetPositionAndRotation(
            bulletStartTransform.position, bulletStartTransform.rotation);
        swordTrail.Clear();

        Vector3 duraction = (transform.position - transformForDuraction.position).normalized;
        bulletRigidbody.AddForce(duraction * bulletSpeed + playerRigidbody.velocity,
            ForceMode.Impulse);
    }
}
