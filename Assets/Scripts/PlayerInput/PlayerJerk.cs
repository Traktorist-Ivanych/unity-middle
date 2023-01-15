using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJerk : PlayerInputActionDelay, IInputAbility
{
    [SerializeField] private Transform transformForDuraction;
    [SerializeField] private float jerkSpeed;

    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        if (CanActionExecute)
        {
            Vector3 duraction = (transform.position - transformForDuraction.position).normalized;
            playerRigidbody.AddForce(duraction * jerkSpeed, ForceMode.Impulse);
        }
    }
}
