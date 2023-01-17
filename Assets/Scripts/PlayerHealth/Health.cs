using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HealthAcrions();
    public event HealthAcrions TakeDamageEvent;
    public event HealthAcrions GetCureHpEvent;
    public event HealthAcrions DeathEvent;

    [SerializeField] private float hpMaxValue;
    [SerializeField] private float hpCurrentValue;
    private bool isAlive;

    public bool IsAlive
    {
        get { return isAlive; }
    }

    public bool IsNeedForCure
    {
        get
        {
            if (hpCurrentValue < hpMaxValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void Start()
    {
        isAlive = true;
        hpCurrentValue = hpMaxValue;
    }

    public void TakeDamage(float damageHpValue)
    {
        hpCurrentValue -= damageHpValue;
        if (hpCurrentValue <= 0)
        {
            hpCurrentValue = 0;
            isAlive = false;
        }
        if (isAlive)
        {
            TakeDamageEvent?.Invoke();
        }
        else
        {
            DeathEvent?.Invoke();
        }
    }

    public void GetCureHp(float cureHpValue)
    {
        hpCurrentValue += cureHpValue;
        if (hpCurrentValue > hpMaxValue)
        {
            hpCurrentValue = hpMaxValue;
        }
        GetCureHpEvent?.Invoke();
    }
}
