using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices; //need to call js
public class LeaderboardScript : MonoBehaviour
{
    public enum Names
    {
        Score
    };
    [DllImport("__Internal")]
    private static extern void SetLeaderboardData(string leaderboadName, float leaderboardValue); //call js from plugin UnityScriptToJS.jslib

    public static void SetLeaderboardValue(Names leaderboardName, float val)
    {
        if (TestMode.Value == false)
        {
            SetLeaderboardData(leaderboardName.ToString(), val);
        }
    }
}
