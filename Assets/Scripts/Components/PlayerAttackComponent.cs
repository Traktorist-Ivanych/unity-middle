using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class PlayerAttackComponent : MonoBehaviour, IAbility
{
    public Rigidbody Weapon;
    public Transform WeapontStartTransform;
    public Transform EmptyForDuraction;
    public float ShootDelay = 1.5f;
    public float WeaponSpeed;

    private float currentShootTime = float.MinValue;

    public void Execute()
    {
        if (Time.time > currentShootTime + ShootDelay)
        {
            currentShootTime = Time.time;

            Weapon.transform.SetPositionAndRotation(WeapontStartTransform.position, transform.rotation);

            Vector3 duraction = (transform.position - EmptyForDuraction.transform.position).normalized;
            //  ак получить вектор направлени€ из Transform.Rotation?
            // „тобы не добавл€ть пустышку дл€ вычислени€ направлени€ реализованным мной способом

            Weapon.velocity = Vector3.zero;
            Weapon.AddForce(duraction * WeaponSpeed, ForceMode.Impulse);
        }
    }
}
