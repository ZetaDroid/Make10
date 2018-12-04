using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int spritesVanished;
    public static int tenInbox;

    public bool isBoxLvl = false;
    public int boxes;
    public Transform numbers;
    public Transform levelCompleteUI;

    private float totalSprites;

    void Start()
    {
        spritesVanished = 0;
        tenInbox = 0;
        totalSprites = numbers.childCount;
        Debugger.Log("Total: " + totalSprites);
        levelCompleteUI.gameObject.SetActive(false);

    }

    void LateUpdate()
    {
        if (isBoxLvl)
        {
            if(tenInbox == boxes && totalSprites == spritesVanished)
            {
                LevelCleared();
            }
        }
        else
        {
            if(totalSprites == spritesVanished)
            {
                LevelCleared();
            }
        }
    }
    public static void Gone(int howMany)
    {
        spritesVanished += howMany;
        Debugger.Log("SpritesGone: " + spritesVanished);
    }
    public static void TenInBox()
    {
        tenInbox++;
    }
    private void LevelCleared()
    {
        // Stuff to do when level is passed
        levelCompleteUI.gameObject.SetActive(true);
        spritesVanished = 0;
        AudioManager.LevelCleared();
    }
}
