using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputActions : MonoBehaviour
{
    [SerializeField] private MonoBehaviour playerJekr;
    [SerializeField] private MonoBehaviour playerAttack;
    [SerializeField] private MonoBehaviour playerMove;
    private PlayerInputControls inputControls;

    private void Start()
    {
        inputControls = new PlayerInputControls();
        inputControls.Keyboard.Enable();
        if (playerJekr is IInputAbility)
        {
            inputControls.Keyboard.Jerk.started += (playerJekr as IInputAbility).ExecuteInputAbility;
        }
        if (playerAttack is IInputAbility)
        {
            inputControls.Keyboard.Attack.started += (playerAttack as IInputAbility).ExecuteInputAbility;
        }
        if (playerMove is IInputAbility)
        {
            inputControls.Keyboard.Move.started += (playerMove as IInputAbility).ExecuteInputAbility;
            inputControls.Keyboard.Move.performed += (playerMove as IInputAbility).ExecuteInputAbility;
            inputControls.Keyboard.Move.canceled += (playerMove as IInputAbility).ExecuteInputAbility;
        }
    }
}