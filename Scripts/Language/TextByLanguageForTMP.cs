using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextByLanguageForTMP : MonoBehaviour
{
    [SerializeField] private string _ru;
    [SerializeField] private string _eng;
    private void Start()
    {
        SetText();
    }
    public void SetText()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        switch (Languages.CurrentLanguage)
        {
            case Languages.AllLanguages.Rus:
                text.text = _ru;
                break;
            case Languages.AllLanguages.Eng:
                text.text = _eng;
                break;
        }
    }
}
