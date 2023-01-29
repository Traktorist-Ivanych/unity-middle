using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHide : PlayerInputActionDelay, IInputAbility
{
    [SerializeField] private SkinnedMeshRenderer skinnedMesh;
    [SerializeField] private Material playerMaterial;
    private bool executeHideActions;
    private float materialHideTime = 1;
    private float currentHideActionTime;

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
                playerMaterial.SetFloat("TimeToHide", materialHideTime);
                Debug.Log(playerMaterial.GetFloat("TimeToHide"));
                skinnedMesh.material = playerMaterial;
            }
            else if (currentHideActionTime >= 6f)
            {
                materialHideTime += Time.deltaTime;
                if (materialHideTime >= 1)
                {
                    materialHideTime = 1;
                }
                playerMaterial.SetFloat("TimeToHide", materialHideTime);
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
