using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerMove : MonoBehaviour, IInputAbility, IConfigurable
{
    private Rigidbody playerRigidbody;
    private Transform playerTransform;
    private Vector2 readPlayerInput;
    private float moveSpeed;

    public IConfiguration Configuration { get; set; }

    private void Start()
    {
        moveSpeed = Configuration.PlayerMoveSpeed;
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }

    [Inject]
    public void LoadConfiguration(IConfiguration config)
    {
        Configuration = config;
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
