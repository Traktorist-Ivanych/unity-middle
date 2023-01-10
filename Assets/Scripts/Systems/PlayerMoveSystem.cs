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

        //� ����� ����������� rigidbody.AddForce � Quaternion.LookRotation � ����� ������� ForEach,
        //�� ���� ������ (��� � �����, ��� ���������� ForEach ����������� 2 ������ � ���������,
        //����������� IComponentData), ��������� �� ��������� �������� � 2 �������� ForEach?
        //��� ��������� ����� ����������� �������� ������� ����, ��� ����������� ����� � �����?
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
