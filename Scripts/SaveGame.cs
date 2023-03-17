using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private Save save = new Save();

    [DllImport("__Internal")]
    private static extern void SaveData(string data); //call js from plugin UnityScriptToJS.jslib

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(){
        SaveProgress();
    }
#endif
    private void OnApplicationQuit()
    {
        SaveProgress();
    }

    public void SaveProgress()
    {
        CreateSaveData();
        SavePlayerPrefs();
        SaveInYandex();
    }
    private void CreateSaveData()
    {
        save.example = 1;
    }
    private void SavePlayerPrefs()
    {
        SaveJson(save);
    }
    private void SaveInYandex()
    {
        SaveData(JsonUtility.ToJson(save));
    }
    public void SaveJson(Save save)
    {
        PlayerPrefs.SetString("SV", JsonUtility.ToJson(save));
        PlayerPrefs.Save();
    }
}
[Serializable]
public class Save
{
    public int example;
}