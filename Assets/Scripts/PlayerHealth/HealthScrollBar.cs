using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthScrollBar : MonoBehaviour
{
    [SerializeField] private ViewModel viewModel;
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
        health.TakeDamageEvent += UpdateHealthScrollBar;
        health.GetCureHpEvent += UpdateHealthScrollBar;
        health.DeathEvent += SetHealthScrollBarOnDie;
    }

    public void UpdateHealthScrollBar()
    {
        viewModel.HealthScrollBarSize = health.CurrentHp / health.HpMaxValue;
    }

    public void SetHealthScrollBarOnDie()
    {
        viewModel.HealthScrollBarSize = 0;
    }
}
