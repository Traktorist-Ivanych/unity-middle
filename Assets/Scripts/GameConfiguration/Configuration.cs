using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuration : IConfiguration
{
    private float maxPlayerHP = 500;
    private float playerMoveSpeed = 250;

    public float MaxPlayerHP => maxPlayerHP;
    public float PlayerMoveSpeed => playerMoveSpeed;
}
