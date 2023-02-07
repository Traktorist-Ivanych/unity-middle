using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryActionItem
{
    public void OnItemInstantiation(MonoBehaviour targetActionScpipt);

    public void ExecuteInventoryAction();
}
