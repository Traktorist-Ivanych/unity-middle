using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour, IInputAbility
{
    [SerializeField] private float moveSpeed;
    private Rigidbody playerRigidbody;
    private Transform playerTransform;
    private Vector2 readPlayerInput;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Vector3 duraction = new Vector3(readPlayerInput.x, 0, readPlayerInput.y).normalized;
        playerRigidbody.AddForce(duraction * moveSpeed, ForceMode.Force);

        if (duraction != Vector3.zero)
        {
            playerTransform.rotation = Quaternion.LookRotation(duraction);
        }
    }

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        readPlayerInput = context.ReadValue<Vector2>();
    }
}
