using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelFromInput : MonoBehaviour
{
    //This whole fucking Class is Experimental and for Debug purposes only;
    //No way this script or the GameObject(s) associated with it should make the final build;

    public InputField input;

    private int totalSceneCount;
    void Start()
    {
        totalSceneCount = SceneManager.sceneCountInBuildSettings;
        Debugger.Log("Static AudioSource enabled");
        Debugger.Log("TotalSceneCount: " + totalSceneCount);
    }

    public void LoadFromString()
    {
        int levelIndex;
        try
        {
            levelIndex = int.Parse(input.text);
            if (levelIndex < totalSceneCount)
            {
                SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
            }
            else
            {
                Debugger.Log("Level not found :>>" + "LIndex: " + levelIndex);
            }
        }
        catch
        {
            Debugger.Log("Unsupported string type. Input Integers.");
        }
        
    }
	
}
