using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : PlayerInputActionDelay, IInputAbility
{
    [SerializeField] private Rigidbody bulletRigidbody;
    [SerializeField] private Transform transformForDuraction;
    [SerializeField] private Transform bulletStartTransform;
    [SerializeField] private float bulletSpeed;

    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        if (CanActionExecute)
        {
            bulletRigidbody.velocity = Vector3.zero;
            bulletRigidbody.transform.SetPositionAndRotation(
                bulletStartTransform.position, transform.rotation);

            Vector3 duraction = (transform.position - transformForDuraction.position).normalized;
            bulletRigidbody.AddForce(duraction * bulletSpeed + playerRigidbody.velocity, 
                ForceMode.Impulse);
        }
    }
}
