using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown toolSettingDropdown;

    private void Start()
    {
        LoadSettings(); //ABSTRACTION
    }

    private void LoadSettings()
    {
        if(!DataManager.Instance)
        {
            return;
        }

        toolSettingDropdown.value = DataManager.Instance.ToolIndex;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateToolSetting()
    {
        if(!DataManager.HasInstance)
            return;

        DataManager.Instance.ToolIndex = toolSettingDropdown.value;
    }
}
