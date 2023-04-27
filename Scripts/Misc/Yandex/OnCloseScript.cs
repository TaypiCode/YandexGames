using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCloseScript : MonoBehaviour
{
    private SaveGame _save;
    private void Start()
    {
        _save = FindObjectOfType<SaveGame>();
    }
    public void OnClose()
    {
        _save.SaveProgress();
    }
}
