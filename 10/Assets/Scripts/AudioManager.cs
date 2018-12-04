using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioSource bg, pop, denied, levelCleared;

    static GameObject instance;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        bg = transform.Find("BGM").gameObject.GetComponent<AudioSource>();
        pop = transform.Find("Pop").gameObject.GetComponent<AudioSource>();
        denied = transform.Find("Denied").gameObject.GetComponent<AudioSource>();
        levelCleared = transform.Find("LevelPassed").gameObject.GetComponent<AudioSource>();
        instance = this.gameObject;
    }

    public static void Pop()
    {
        if(bg && pop)
        {
            if (!pop.isPlaying) pop.Play();
        }
    }
    public static void Deny()
    {
        if(denied != null)
        {
            if (!denied.isPlaying) denied.Play();
        }
    }
    public static void LevelCleared()
    {
        if (levelCleared != null)
        {
            if (!levelCleared.isPlaying) levelCleared.Play();
        }
    }
    public static void Restart()
    {
        Destroy(instance);
    }
    
}
