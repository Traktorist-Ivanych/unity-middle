using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerAttackSystem : ComponentSystem
{
    private EntityQuery attackQuery;

    protected override void OnCreate()
    {
        attackQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<ShootData>(),
            ComponentType.ReadOnly<PlayerInputData>());
    }

    protected override void OnUpdate()
    {
        Entities.With(attackQuery).ForEach(
            (Entity entity, PlayerInputData playerInputData, ref InputData inputData) =>
            {
                if (inputData.Attack > 0)
                {
                    (playerInputData.ShootAction as IAbility).Execute();
                }
            });
    }
}
