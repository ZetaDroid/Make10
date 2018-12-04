using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Debugger : MonoBehaviour
{
    public static Text debugTxt;

    void Awake()
    {
        debugTxt = this.gameObject.GetComponent<Text>();
    }

   

    public static void Log(string logTxt)
    {
        if (debugTxt != null)
        {
            debugTxt.text = debugTxt.text + "\n"+" .>> " + logTxt;
        }
    }
    public static void ClearLog()
    {
        if (debugTxt != null)
        {
            debugTxt.text = "";
        }
    }
    public static void NewLog(string log)
    {
        if (debugTxt != null)
        {
            debugTxt.text = log;
        }
    }

}
