using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Задержка выполнения действия пользовательского ввода
/// </summary>
public class PlayerInputActionDelay : MonoBehaviour
{
    [SerializeField] private float actionDelay;
    private float currentActionTime = float.MinValue;

    /// <summary>
    /// Возвращает true, если задержка прошла. Иначе - false
    /// </summary>
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
