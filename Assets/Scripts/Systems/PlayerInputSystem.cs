using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : ComponentSystem
{
    private EntityQuery inputQuery;
    private InputAction moveAction;
    private float2 inputMove;

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
        moveAction.performed += callbackContext => { inputMove = callbackContext.ReadValue<Vector2>(); };
        moveAction.started += callbackContext => { inputMove = callbackContext.ReadValue<Vector2>(); };
        moveAction.canceled += callbackContext => { inputMove = callbackContext.ReadValue<Vector2>(); };
        moveAction.Enable();
    }

    protected override void OnStopRunning()
    {
        moveAction.Enable();
    }

    protected override void OnUpdate()
    {
        Entities.With(inputQuery).ForEach((Entity entity, ref InputData playerInputData) => 
        {
            playerInputData.PlayerMove = inputMove;
        });
    }
}
