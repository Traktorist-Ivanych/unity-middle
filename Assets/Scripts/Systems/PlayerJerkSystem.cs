using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerJerkSystem : ComponentSystem
{
    private EntityQuery jerkQuery;

    protected override void OnCreate()
    {
        jerkQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<JerkData>(),
            ComponentType.ReadOnly<PlayerInputData>());
    }

    protected override void OnUpdate()
    {
        Entities.With(jerkQuery).ForEach(
            (Entity entity, PlayerInputData playerInputData, ref InputData inputData) =>
            {
                if (inputData.Jerk > 0)
                {
                    (playerInputData.JerkAction as IAbility).Execute();
                }
            });
    }
}
