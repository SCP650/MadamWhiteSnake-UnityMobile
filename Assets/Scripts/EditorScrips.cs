using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

using UnityEditor.SceneManagement;

class EditorScrips : EditorWindow
{
    [MenuItem("Play/PlayMe _%g")]

    public static void RunMainScene()
    {
        if (!EditorApplication.isPlaying)
        {
            string currentSceneName = EditorApplication.currentScene;
            File.WriteAllText(".lastScene", currentSceneName);

            EditorApplication.OpenScene("Assets/Scenes/Startup.unity");
            EditorApplication.isPlaying = true;
        }
        if (EditorApplication.isPlaying)
        {
            //EditorApplication.isPaused = false;
            EditorApplication.isPlaying = false;
           
        }
    }

    [MenuItem("Play/GoBack _%y")]
    public static void ReturnToPrevious()
    {
        string lastScene = File.ReadAllText(".lastScene");
        EditorApplication.OpenScene(lastScene);
    }

}