using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllId : MonoBehaviour
{
    public static List<ISavableObject> SavableObjectsList = new List<ISavableObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            FindDuplicate();
        }
    }

    public void FindDuplicate()
    {
        HashSet<string> savebleObjectsId = new HashSet<string>();
        foreach (ISavableObject savableObject in SavableObjectsList)
        {
            if (savebleObjectsId.Add(savableObject.Id) == false)
            {
                Debug.LogError("Id duplicate! Id = " + savableObject.Id);
                return;
            }
        }
        Debug.Log("Duplicate not found");
    }
}
