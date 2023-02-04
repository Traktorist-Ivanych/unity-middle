using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuration : MonoBehaviour, IConfiguration
{
    [SerializeField] private float maxPlayerHP = 500;
    [SerializeField] private float playerMoveSpeed = 250;

    public float MaxPlayerHP 
    { 
        get => maxPlayerHP;
        set 
        { 
            if (value > 0)
            {
                maxPlayerHP = value;
            }
            else
            {
                Debug.LogError("MaxPlayerHP out of range!");
            }
        }
    }
    public float PlayerMoveSpeed
    {
        get => playerMoveSpeed;
        set
        {
            if (value > 0)
            {
                playerMoveSpeed = value;
            }
            else
            {
                Debug.LogError("PlayerMoveSpeed out of range!");
            }
        }
    }
}
