using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    private Save _save;
    private static bool _firstLoad = true;
    private static bool _isMobile;

    public static bool IsMobile { get => _isMobile;  }

    [DllImport("__Internal")]
    private static extern void FirstLoadInSession(); //call js from plugin UnityScriptToJS.jslib

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SV"))
        {
            _save = new Save();
            _save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
        }
        if (!_firstLoad)
        {
            LoadData();
        }

    }
    private void Start()
    {
        if (_firstLoad)
        {
            FirstLoadInSession();
        }
    }
    public void LoadFromYandex(string data)
    {
        _save = new Save();
        _save = JsonUtility.FromJson<Save>(data);
        FindObjectOfType<SaveGame>().SaveJson(_save);
        LoadData();
    }

    public void LoadData()
    {
        if (_save != null)
        {
            int example = _save.example;
            
        }
        else
        {
            //no save
        }
        _firstLoad = false;
    }
    public void SetIsMobile()
    {
        _isMobile = true;
    }
}
