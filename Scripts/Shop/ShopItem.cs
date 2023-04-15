using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private ShopScript.YandexPurchaseItemId _item;
    [SerializeField] private GameObject _itemObj;
    [SerializeField] private TextMeshProUGUI _buyBtnText;

    public ShopScript.YandexPurchaseItemId ItemId { get => _item;  }
    public void TryBuy()
    {
        FindObjectOfType<ShopScript>().TryBuy(_item, delegate { Reward(); }) ;
    }
    public virtual void Reward()
    {

    }
    public void SetAvailable(bool available, string priceWithCurrency)
    {
        _itemObj.SetActive(available);
        if (available)
        {
            string text = "";
            switch (Languages.CurrentLanguage)
            {
                case Languages.AllLanguages.Rus:
                    text = "Купить ";
                    break;
                case Languages.AllLanguages.Eng:
                    text = "Buy ";
                    break;
            }
            _buyBtnText.text = text + priceWithCurrency;
        }
    }
}
