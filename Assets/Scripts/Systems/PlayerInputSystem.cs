using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : ComponentSystem
{
    private EntityQuery inputQuery;
    private InputAction moveAction;
    private InputAction attackAction;
    private InputAction jerkAction;
    private float2 inputMove;
    private bool isJoustickWork;
    private float attackInput;
    private float jerkInput;

    protected override void OnCreate()
    {
        inputQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    protected override void OnStartRunning()
    {
        moveAction = new InputAction(name: "Move", binding: "<Gamepad>/rightStick");
        moveAction.AddCompositeBinding("Dpad")
            .With(name: "Up", binding: "<Keyboard>/w")
            .With(name: "Down", binding: "<Keyboard>/s")
            .With(name: "Left", binding: "<Keyboard>/a")
            .With(name: "Right", binding: "<Keyboard>/d");
        moveAction.performed += callbackContext => 
        { 
            inputMove = callbackContext.ReadValue<Vector2>();
            isJoustickWork = true;
        };
        moveAction.started += callbackContext => 
        { 
            inputMove = callbackContext.ReadValue<Vector2>();
            isJoustickWork = true;
        };
        moveAction.canceled += callbackContext => 
        { 
            inputMove = callbackContext.ReadValue<Vector2>();
            isJoustickWork = false;
        };
        moveAction.Enable();

        attackAction = new InputAction(name: "Attack", binding: "<Keyboard>/E");
        attackAction.started += callbackContext => { attackInput = callbackContext.ReadValue<float>(); };
        attackAction.performed += callbackContext => { attackInput = callbackContext.ReadValue<float>(); };
        attackAction.canceled += callbackContext => { attackInput = callbackContext.ReadValue<float>(); };
        attackAction.Enable();

        jerkAction = new InputAction(name: "Jerk", binding: "<Keyboard>/Space");
        jerkAction.started += callbackContext => { jerkInput = callbackContext.ReadValue<float>(); };
        jerkAction.performed += callbackContext => { jerkInput = callbackContext.ReadValue<float>(); };
        jerkAction.canceled += callbackContext => { jerkInput = callbackContext.ReadValue<float>(); };
        jerkAction.Enable();
    }

    protected override void OnStopRunning()
    {
        moveAction.Disable();
        attackAction.Disable();
        jerkAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(inputQuery).ForEach((Entity entity, ref InputData playerInputData) => 
        {
            playerInputData.PlayerMove = inputMove;
            playerInputData.IsPlayerMove = isJoustickWork;
            playerInputData.Attack = attackInput;
            playerInputData.Jerk = jerkInput;
        });
    }
}
