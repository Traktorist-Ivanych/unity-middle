using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRotationController : MonoBehaviour
{
    [SerializeField] private float timeToChangeRotation;
    [SerializeField] private float maxRotationValue;
    [SerializeField] private float minRotationValue;
    private HingeJoint trapHingeJoint;
    private float currentTimeToChangeRotation;

    private void Start()
    {
        currentTimeToChangeRotation = timeToChangeRotation;
        trapHingeJoint = GetComponent<HingeJoint>();
    }

    private void Update()
    {
        currentTimeToChangeRotation -= Time.deltaTime;

        if (currentTimeToChangeRotation <= 0)
        {
            currentTimeToChangeRotation = timeToChangeRotation;

            JointMotor trapMotor = new JointMotor();
            trapMotor.force = Random.Range(minRotationValue, maxRotationValue);
            trapMotor.targetVelocity = Random.Range(minRotationValue, maxRotationValue);

            trapHingeJoint.motor = trapMotor;
        }
    }
}
