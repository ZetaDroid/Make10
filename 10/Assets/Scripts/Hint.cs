using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public Vector3 camDownPosition,camUpPosition;
    //public Animator anim;
    public Transform hintPanel;
    public bool isThereSomethingNew;
    
    private bool isShowing;
    

    //for checking with Addlistener;
    public static bool toShowHint;

    void Start()
    {
        toShowHint = true; /////////////////////////////////// Must Change to false; 
        if(isThereSomethingNew)
        {
            HintButtonPressed();
            //toShowHint = true;/////////////////////////////////Must UnComment;
        }
    }
    
    public void HintButtonPressed()/////////////////////// Must change. This method will only evaluate Addmanager's callback;
    {
        ShowHint();
    } 

    private void ShowHint()
    {
        if (toShowHint)
        {
            if (isShowing)
            {
                //anim.SetTrigger("hide");
                hintPanel.gameObject.SetActive(false);
                isShowing = false;
                Camera.main.transform.position = camUpPosition;
            }
            else
            {
                //anim.SetTrigger("show");
                isShowing = true;
                hintPanel.gameObject.SetActive(true);
                Camera.main.transform.position = camDownPosition;
            }
        }
    }
}
