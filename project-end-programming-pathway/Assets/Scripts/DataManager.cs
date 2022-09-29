using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; } //ENCAPSULATION
    public static bool HasInstance => Instance!=null; //Expression bodied member (=getter)

    public int ToolIndex { get; set; }
    //0: Laser
    //1: Bubble

    private void Start()
    {
        if(Instance != null) // An instance already exists
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        ToolIndex = 0;
    }
}
