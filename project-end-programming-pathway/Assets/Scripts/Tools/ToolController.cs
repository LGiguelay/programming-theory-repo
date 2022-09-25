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
        PlaceInHand();
    }
    private void SpawnTool()
    {
        if(toolBluePrints.Count<1)
        {
            return;
        }

        GameObject currentToolInstance = Instantiate(toolBluePrints[0], transform);
        currentTool = toolBluePrints[0].GetComponent<Tool>();
        

    }
    private void PlaceInHand()
    {

    }
}
