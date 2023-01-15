using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInputAbility
{
    void ExecuteInputAbility(InputAction.CallbackContext context);
}
