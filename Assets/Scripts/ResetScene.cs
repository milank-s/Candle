using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
  void Update()
    {
        // Reload scene when R key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }

        // Close application when Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseApplication();
        }
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void CloseApplication()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
