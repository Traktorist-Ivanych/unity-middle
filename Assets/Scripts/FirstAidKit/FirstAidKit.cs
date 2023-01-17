using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float hpToCure;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Health health))
        {
            if (health.IsNeedForCure)
            {
                health.GetCureHp(hpToCure);
                gameObject.SetActive(false);
            }
        }
    }
}
