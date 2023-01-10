using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerMoveSystem : ComponentSystem
{
    private EntityQuery moveQuery;
    private Vector3 duraction;

    protected override void OnCreate()
    {
        moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<MoveData>(),
            ComponentType.ReadOnly<Rigidbody>(),
            ComponentType.ReadOnly<Transform>());
    }

    protected override void OnUpdate()
    {
        Entities.With(moveQuery).ForEach(
            (Entity entity, Rigidbody rigidbody, ref InputData inputData, ref MoveData moveData) =>
            {
                duraction = new Vector3(inputData.PlayerMove.x, 0, inputData.PlayerMove.y);

                rigidbody.AddForce(duraction * moveData.PlayerSpeedComponent);
            });

        //я хотел реализовать rigidbody.AddForce и Quaternion.LookRotation в одном запросе ForEach,
        //но была ошибка (как я понял, нет перегрузки ForEach принимающей 2 класса и структуры,
        //реализующие IComponentData), правильно ли разделить действия в 2 запросах ForEach?
        //или правильно будет реализовать движение подобно тому, как реализована атака и рывок?
        Entities.With(moveQuery).ForEach(
            (Entity entity, Transform transform, ref InputData inputData) =>
            {
                if (inputData.IsPlayerMove)
                {
                    Quaternion quaternion = Quaternion.LookRotation(duraction, Vector3.up);

                    transform.rotation = quaternion;
                }
            });

    }
}
