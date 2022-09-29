using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] private List<GameObject> toolBluePrints;
    private Tool currentTool;
    private int toolIndex;

    private void Start()
    {
        toolIndex = GetToolIndexFromDataManager(); //ABSTRACTION
        SpawnTool(); //ABSTRACTION
    }

    private int GetToolIndexFromDataManager()
    {
        if(!DataManager.HasInstance)
        {
            return 0;
        }

        int index = DataManager.Instance.ToolIndex;

        if(index > toolBluePrints.Count || index < 0)
        {
            return 0;
        }

        return index;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UseTool(); //ABSTRACTION
        }
    }
    private void SpawnTool()
    {
        if(toolBluePrints.Count<1)
        {
            return;
        }

        GameObject currentToolInstance = Instantiate(toolBluePrints[toolIndex], transform);
        currentTool = currentToolInstance.GetComponent<Tool>();

    }
    
    private void UseTool()
    {
        if (currentTool == null)
            return;

        currentTool.Use();
    }
}
