using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveVelosityAndTransform : SavableObject
{
    private Transform objTransform;
    private Rigidbody objRigidbody;

    protected override void OnStart()
    {
        objTransform = GetComponent<Transform>();
        objRigidbody = GetComponent<Rigidbody>();
    }

    public override void Save()
    {
        VelosityAndTransformDataToSave dataToSave = new VelosityAndTransformDataToSave(
            objTransform.position, objTransform.rotation.eulerAngles, 
            objRigidbody.velocity, objRigidbody.angularVelocity);

        string savedData = JsonUtility.ToJson(dataToSave);

        SavesManager.AddObjectDataIntoList(id, savedData);
    }

    public override void Load()
    {
        VelosityAndTransformDataToSave loadedData =
            JsonUtility.FromJson<VelosityAndTransformDataToSave>(SavesManager.GetObjectData(id));
        if (loadedData != null)
        {
            objTransform.position = loadedData.Position;
            Quaternion quaternion = new Quaternion
            {
                eulerAngles = loadedData.Rotation
            };
            objTransform.rotation = quaternion;

            objRigidbody.velocity = loadedData.Velocity;
            objRigidbody.angularVelocity = loadedData.AngularVelocity;
        }
    }

    [Serializable]
    private class VelosityAndTransformDataToSave
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Velocity;
        public Vector3 AngularVelocity;

        public VelosityAndTransformDataToSave(Vector3 pos, Vector3 rot, Vector3 vel, Vector3 anVel)
        {
            Position = pos;
            Rotation = rot;
            Velocity = vel;
            AngularVelocity = anVel;
        }
    }
}
