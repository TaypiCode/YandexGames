using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    [SerializeField] private Promocode _promocode;
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
        if (TestMode.Value == false)
        {
            SaveInYandex();
        }
        
    }
    private void CreateSaveData()
    {
        save.currentLanguage = Languages.CurrentLanguage.ToString();
        save.activatedPromocodes = _promocode.GetActivatedPromocodes();
        LeaderboardScript.SetLeaderboardValue(LeaderboardScript.Names.Score, PlayerData.Score);
    }
    private void SavePlayerPrefs()
    {
        SaveJson(save);
    }
    private void SaveInYandex() //сохраняется какое то количество времени, при закрытии игра не успеет сохраниться, поэтому нужны промежуточные сохранения(после боя, при каком то действии)
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
    public string currentLanguage;
    public string[] activatedPromocodes;
}