using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerMove : PlayerInputActionPossibility, IInputAbility, IConfigurable
{
    [SerializeField] private float runningAnimSpeedDivider;
    private Animator playerAnimator;
    private Rigidbody playerRigidbody;
    private Transform playerTransform;
    private Vector2 readPlayerInput;
    private float moveSpeed;
    private string runningParameterName = "IsRunning";
    private string runningSpeedParameterName = "RunningSpeed";

    public IConfiguration Configuration { get; set; }

    private protected override void OnStart()
    {
        moveSpeed = Configuration.PlayerMoveSpeed;
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
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

    private void Update()
    {
        if (playerRigidbody.velocity.magnitude > 0.025f && readPlayerInput.magnitude > 0.025f)
        {
            playerAnimator.SetBool(runningParameterName, true);
            float playerRunningAnimSpeed = playerRigidbody.velocity.magnitude / runningAnimSpeedDivider;
            playerAnimator.SetFloat(runningSpeedParameterName, playerRunningAnimSpeed);
        }
        else
        {
            playerAnimator.SetBool(runningParameterName, false);
        }
    }

    [Inject]
    public void LoadConfiguration(IConfiguration config)
    {
        Configuration = config;
    }

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        if (CanActionExecute)
        {
            readPlayerInput = context.ReadValue<Vector2>();
        }
        else
        {
            readPlayerInput = Vector2.zero;
        }
    }
}
