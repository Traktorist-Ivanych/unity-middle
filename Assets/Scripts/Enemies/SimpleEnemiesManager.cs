using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemiesManager : MonoBehaviour
{
    private IEnemy[] IEnemiesList;
    private IEnemy highestValueIEnemy;
    private float maxEvaluateValue;

    private void Start()
    {
        IEnemiesList = GetComponents<IEnemy>();
    }

    private void Update()
    {
        highestValueIEnemy = null;
        maxEvaluateValue = float.MinValue;

        foreach(IEnemy enemy in IEnemiesList)
        {
            float currentEvaluateValue = enemy.Evaluate();
            if (currentEvaluateValue > maxEvaluateValue)
            {
                maxEvaluateValue = currentEvaluateValue;
                highestValueIEnemy = enemy;
            }
        }
        highestValueIEnemy.Perform();
    }
}
