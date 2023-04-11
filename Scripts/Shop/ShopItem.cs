using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private ShopScript.YandexPurchaseItemId _item;
    public void TryBuy()
    {
        FindObjectOfType<ShopScript>().TryBuy(_item, delegate { Reward(); }) ;
    }
    public virtual void Reward()
    {

    }
}
