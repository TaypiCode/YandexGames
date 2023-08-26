using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private Languages _language;
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
    }
    private void Start()
    {
        if (_firstLoad)
        {
            if (TestMode.Value == true)
            {
                LoadData();
            }
            else
            {
                FirstLoadInSession();
            }
        }
        else
        {
            LoadData();
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
            if (_save.currentLanguage != null)
            {
                _language.SetLanguage(_save.currentLanguage, false);
            }
            else
            {
                _language.ShowChooseLanguage();
            }
            if (_save.activatedPromocodes != null)
            {
                FindObjectOfType<Promocode>().FillActivatedPromocodes(_save.activatedPromocodes);
            }
        }
        else
        {
            //no save
        }
        FindObjectOfType<ShopScript>().SetItems();
        _firstLoad = false;
    }
    public void SetIsMobile()
    {
        _isMobile = true;
    }
}
