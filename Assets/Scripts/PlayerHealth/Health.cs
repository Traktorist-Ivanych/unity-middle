using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Health : MonoBehaviour, IConfigurable
{
    public delegate void HealthActions();
    public event HealthActions TakeDamageEvent;
    public event HealthActions GetCureHpEvent;
    public event HealthActions DeathEvent;

    [SerializeField] private float hpCurrentValue;
    private float hpMaxValue;
    private bool isAlive;

    public bool IsAlive
    {
        get { return isAlive; }
    }

    public float CurrentHp
    {
        get => hpCurrentValue;
        set { hpCurrentValue = value; }
    }

    public float HpMaxValue
    {
        get => hpMaxValue;
    }

    public bool IsNeedForCure
    {
        get
        {
           return hpCurrentValue < hpMaxValue;
        }
    }

    public IConfiguration Configuration { get; set; }

    [Inject]
    public void LoadConfiguration(IConfiguration config)
    {
        Configuration = config;
    }

    private void Start()
    {
        hpMaxValue = Configuration.MaxPlayerHP;
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
