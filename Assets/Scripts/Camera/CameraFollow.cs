using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float indent;

    private void FixedUpdate()
    {
        Vector3 position = new Vector3(targetTransform.position.x, 
            targetTransform.position.y + indent, targetTransform.position.z);
        transform.position = position;
    }
}
