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
            (Entity entity, Rigidbody rigidbody, ref InputData playerInputData, ref MoveData moveData) =>
            {
                duraction = new Vector3(playerInputData.PlayerMove.x, 0, playerInputData.PlayerMove.y);

                rigidbody.AddForce(duraction * moveData.PlayerSpeedComponent, ForceMode.Impulse);
            });

        //� ����� ����������� rigidbody.AddForce � Quaternion.LookRotation � ����� ������� ForEach,
        //�� ���� ������ (��� � �����, ��� ���������� ForEach ����������� 2 ������ � ���������,
        //����������� IComponentData), ��������� �� ��������� �������� � 2 �������� ForEach?
        Entities.With(moveQuery).ForEach(
            (Entity entity, Transform transform, ref InputData playerInputData, ref MoveData moveData) =>
            {
                Quaternion quaternion = Quaternion.LookRotation(duraction, Vector3.up);

                transform.rotation = quaternion;
            });

    }
}
