using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ���������� �������� ����������������� �����
/// </summary>
public class PlayerInputActionDelay : MonoBehaviour
{
    [SerializeField] private float actionDelay;
    private float currentActionTime = float.MinValue;

    /// <summary>
    /// ���������� true, ���� �������� ������. ����� - false
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
