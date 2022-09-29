using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
