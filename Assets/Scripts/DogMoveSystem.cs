using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class DogMoveSystem : ComponentSystem
{
    private EntityQuery query;

    protected override void OnCreate()
    {
        query = GetEntityQuery(ComponentType.ReadOnly<DogMoveComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(query).ForEach((Entity entity, Transform dogTransform, DogMoveComponent dogMove) =>
        {
            Vector3 dogPositionNew = dogTransform.position;
            dogPositionNew.z += dogMove.MoveSpeed / 1000;
            dogTransform.position = dogPositionNew;
        });
    }
}
