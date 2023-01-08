using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    private static int currentSceneIndex;

    public static void SetCurrentSceneIndex()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public static void LoadAnyScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
