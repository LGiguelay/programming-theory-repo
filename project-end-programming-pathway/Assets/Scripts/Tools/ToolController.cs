using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] private List<GameObject> toolBluePrints;
    private Tool currentTool;

    private void Start()
    {
        SpawnTool();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }
    private void SpawnTool()
    {
        if(toolBluePrints.Count<1)
        {
            return;
        }

        GameObject currentToolInstance = Instantiate(toolBluePrints[0], transform);
        currentTool = currentToolInstance.GetComponent<Tool>();

    }
    
    private void UseTool()
    {
        if (currentTool == null)
            return;

        currentTool.Use();
    }
}
