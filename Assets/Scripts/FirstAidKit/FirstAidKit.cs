using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float hpToCure;
    private bool isUsed = false;

    public bool IsUsed
    {
        get => isUsed;
        set { isUsed = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Health health))
        {
            if (health.IsNeedForCure)
            {
                health.GetCureHp(hpToCure);
                isUsed = true;
                gameObject.SetActive(false);
            }
        }
    }

    public void ActiveOrNot(bool isFirstAidKitUsed)
    {
        IsUsed = isFirstAidKitUsed;
        gameObject.SetActive(!isFirstAidKitUsed);
    }
}
