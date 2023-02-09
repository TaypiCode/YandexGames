using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    private Save _save;
    private void Awake()
    {
        _save = new Save();
        if (PlayerPrefs.HasKey("SV"))
        {
            _save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
            int example = _save.example;
        }
    }
}
