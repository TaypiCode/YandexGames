using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "ItemScriptable", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    [ScriptableObjectId] public string itemId;

    [SerializeField] private string _itemNameRus;
    [SerializeField] private string _itemNameEng;

    public string ItemName 
    {
        get
        {
            switch (Languages.CurrentLanguage)
            {
                case Languages.AllLanguages.Rus:
                    return _itemNameRus;
                case Languages.AllLanguages.Eng:
                    return _itemNameEng;
            }
            return _itemNameEng;
        }
    }
}
