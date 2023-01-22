using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButtons : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private MonoBehaviour onScreenButtonSave;
    [SerializeField] private Button loadButton;
    [SerializeField] private MonoBehaviour onScreenButtonLoad;

    private void Start()
    {
        SavesManager.OnSaveStart += SetButtonsActive;
        PlayFabTools.OnSaveEnd += SetButtonsActive;
        PlayFabTools.OnLoadStart += SetButtonsActive;
        SavesManager.OnLoadEnd += SetButtonsActive;
    }

    public void SetButtonsActive(bool flag)
    {
        saveButton.interactable = flag;
        onScreenButtonSave.enabled = flag;
        loadButton.interactable = flag;
        onScreenButtonLoad.enabled = flag;
    }
}
