using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices; //need to call js
public class RateUsScript : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RateUs(); //call js from plugin UnityScriptToJS.jslib

    public static void ShowRateUs()
    {
        RateUs();
    }
}
