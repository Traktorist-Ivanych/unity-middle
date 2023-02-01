using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputActionPossibility : MonoBehaviour
{
    [SerializeField] private float actionDelay;
    private Health playerHealth;
    private float currentActionTime = float.MinValue;

    private void Start()
    {
        playerHealth = GetComponent<Health>();
        OnStart();
    }

    private protected bool CanActionExecute
    {
        get
        {
            if (Time.time >= currentActionTime + actionDelay && playerHealth.IsAlive)
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

    private protected virtual void OnStart()
    {

    }
}
