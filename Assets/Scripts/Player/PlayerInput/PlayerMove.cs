using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : PlayerInputActionPossibility, IInputAbility
{
    [SerializeField] private float runningAnimSpeedDivider;
    [SerializeField] private float moveSpeed;
    private Animator playerAnimator;
    private Rigidbody playerRigidbody;
    private Transform playerTransform;
    private Vector2 readPlayerInput;
    private readonly string runningParameterName = "IsRunning";
    private readonly string runningSpeedParameterName = "RunningSpeed";

    private protected override void OnStart()
    {
        playerAnimator = GetComponent<Animator>();
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
