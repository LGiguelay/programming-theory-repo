using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public bool HasInstance => Instance!=null; //Expression bodied member (=getter)


    private void Start()
    {
        if(Instance != null) // An instance already exists
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
