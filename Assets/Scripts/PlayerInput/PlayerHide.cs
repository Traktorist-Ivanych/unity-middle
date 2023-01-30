using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class PlayerHide : PlayerInputActionDelay, IInputAbility
{
    [SerializeField] private Material playerMaterial;
    private bool executeHideActions;
    private float materialHideTime = 1;
    private float currentHideActionTime;
    private string hideMaterialPropertyName = "Vector1_bad362c3d9cd4b628db70be4da5de212";

    private void Start()
    {
        playerMaterial.SetFloat(hideMaterialPropertyName, 1);
    }

    private void Update()
    {
        if (executeHideActions)
        {
            currentHideActionTime += Time.deltaTime;

            if (currentHideActionTime <= 1.1f)
            {
                materialHideTime -= Time.deltaTime;
                if (materialHideTime <= 0)
                {
                    materialHideTime = 0;
                }
                playerMaterial.SetFloat(hideMaterialPropertyName, materialHideTime);
            }
            else if (currentHideActionTime >= 6f)
            {
                materialHideTime += Time.deltaTime;
                if (materialHideTime >= 1)
                {
                    materialHideTime = 1;
                }
                playerMaterial.SetFloat(hideMaterialPropertyName, materialHideTime);
            }

            if (currentHideActionTime >= 7.1f)
            {
                executeHideActions = false;
                currentHideActionTime = 0;
            }
        }
    }

    public void ExecuteInputAbility(InputAction.CallbackContext context)
    {
        if (CanActionExecute)
        {
            executeHideActions = true;
        }
    }
}
