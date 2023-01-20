using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputActionDelay : MonoBehaviour
{
    [SerializeField] private float actionDelay;
    private float currentActionTime = float.MinValue;

     private protected bool CanActionExecute
    {
        get
        {
            if (Time.time > currentActionTime + actionDelay)
            {
                currentActionTime = Time.time;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
