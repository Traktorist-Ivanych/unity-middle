using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour, IFactoryCreation
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float indent;

    private void FixedUpdate()
    {
        if (targetTransform != null)
        {
            Vector3 position = new Vector3(targetTransform.position.x,
                targetTransform.position.y + indent, targetTransform.position.z);
            transform.position = position;
        }
    }
    public void OnInstantiation(Object instantiatedObject)
    {
        (instantiatedObject as GameObject).TryGetComponent<Transform>(out targetTransform);
    }
}
