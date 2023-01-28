using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Configeration", menuName = "Configerations",order = 51)]
public class SOConfiguration : ScriptableObject, IConfiguration
{
    [SerializeField] private float maxPlayerHP;
    [SerializeField] private float playerMoveSpeed;

    public float MaxPlayerHP => maxPlayerHP;
    public float PlayerMoveSpeed => playerMoveSpeed;
}
