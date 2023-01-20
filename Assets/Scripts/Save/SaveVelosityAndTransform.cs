using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveVelosityAndTransform : MonoBehaviour
{
    [SerializeField] private string Id;
    private Transform objTransform;
    private Rigidbody objRigidbody;


    private void Start()
    {
        objTransform = GetComponent<Transform>();
        objRigidbody = GetComponent<Rigidbody>();

        SavesManager.SaveGameEvent += Save;
        SavesManager.LoadGameEvent += Load;
    }

    public void Save()
    {
        ObjectForSaveVelosityAndTransform objectForSave = new ObjectForSaveVelosityAndTransform(
            objTransform.position, objTransform.rotation.eulerAngles, 
            objRigidbody.velocity, objRigidbody.angularVelocity);

        string savedData = JsonUtility.ToJson(objectForSave);

        SavesManager.ObjectsDataList.Add(new SavesManager.ObjectData(Id, savedData));
    }

    public void Load()
    {

    }

    [Serializable]
    public class ObjectForSaveVelosityAndTransform
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Velocity;
        public Vector3 AngularVelocity;

        public ObjectForSaveVelosityAndTransform(Vector3 pos, Vector3 rot, Vector3 vel, Vector3 anVel)
        {
            Position = pos;
            Rotation = rot;
            Velocity = vel;
            AngularVelocity = anVel;
        }
    }
}
