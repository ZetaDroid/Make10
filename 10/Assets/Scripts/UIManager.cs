using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite musicOn, musicOff, sfxOn, sfxOff;//For toggling audio settings;
    private bool isSfxMute, isMusicMute;//For toggling audio settings;


    private string CurrentSceneName;
    private int CurrentSceneIndex;
    private int totalSceneCount;
    void Start()
    {
        CurrentSceneName = SceneManager.GetActiveScene().name;
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        totalSceneCount = SceneManager.sceneCountInBuildSettings;
        Debugger.Log("LEVEL: " + CurrentSceneName);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(CurrentSceneIndex == 0)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
                AudioManager.Restart();
            }
        }
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Reload()
    {
        SceneManager.LoadScene(CurrentSceneName, LoadSceneMode.Single);
    }

    public void LoadNextScene()
    {
        if (CurrentSceneIndex < (totalSceneCount-1))
        {
            SceneManager.LoadScene(CurrentSceneIndex + 1, LoadSceneMode.Single);
        }
    }

    
    public void Slowtime()/////////////////////////////////////////////////////   DEBUG ONLY    //////////////
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0.1f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        Debugger.Log("TimeScale Changed to: " + Time.timeScale);
    }

    private bool isShowing = false;
    public void AudioToggle(Animator anim)
    {
        if (isShowing)
        {
            anim.SetTrigger("hide");
            isShowing = false;
        }
        else
        {
            anim.SetTrigger("show");
            isShowing = true;
        }
    }


    
    

    

	
}
