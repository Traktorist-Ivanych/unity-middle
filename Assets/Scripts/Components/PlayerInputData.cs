using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

public class PlayerInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    public float PlayerSpeed;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData<InputData>(entity, new InputData());
        dstManager.AddComponentData<MoveData>(entity, new MoveData
        {
            PlayerSpeedComponent = PlayerSpeed / 100
        });
    }
}

public struct InputData: IComponentData
{
    public float2 PlayerMove;
}

public struct MoveData: IComponentData
{
    public float PlayerSpeedComponent;
}
