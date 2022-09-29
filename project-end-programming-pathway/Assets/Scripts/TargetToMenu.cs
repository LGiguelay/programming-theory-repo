using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetToMenu : MonoBehaviour
{
    private void OnDestroy()
    {
        SceneManager.LoadScene("Menu");
    }
}
