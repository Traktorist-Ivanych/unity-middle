using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreShopping : MonoBehaviour
{
    [SerializeField] private Text goldValueText;
    private int playerGoldValue;

    public void OnPurchaseComplited(int addingGoldValue)
    {
        playerGoldValue += addingGoldValue;
        goldValueText.text = "Gold: " + playerGoldValue.ToString();
    }
}
