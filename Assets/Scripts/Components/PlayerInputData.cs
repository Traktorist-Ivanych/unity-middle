using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

public class PlayerInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour JerkAction;
    public MonoBehaviour ShootAction;
    public float PlayerSpeed;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData<InputData>(entity, new InputData());
        dstManager.AddComponentData<MoveData>(entity, new MoveData
        {
            PlayerSpeedComponent = PlayerSpeed / 100
        });

        if (ShootAction != null && ShootAction is IAbility)
        {
            dstManager.AddComponentData<ShootData>(entity, new ShootData());
        }

        if (JerkAction != null && JerkAction is IAbility)
        {
            dstManager.AddComponentData<JerkData>(entity, new JerkData());
        }
    }
}

public struct InputData: IComponentData
{
    public float2 PlayerMove;
    public bool IsPlayerMove;
    public float Attack;
    public float Jerk;
}

public struct MoveData: IComponentData
{
    public float PlayerSpeedComponent;
}

public struct ShootData: IComponentData
{

}

public struct JerkData: IComponentData
{

}
