using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices; //need to call js

public class ShopScript : MonoBehaviour
{
    private Action _rewardAction;
    public enum YandexPurchaseItemId //id add in ya games console shop itemId
    {
        removeAds,
        buyPack_1,
        buyPack_2,
        buyPack_3,
    }

    [DllImport("__Internal")]
    private static extern void Purchase(string id); //call js from plugin UnityScriptToJS.jslib
    public void AlreadyBought(string id) //result from js
    {
        if (id == YandexPurchaseItemId.removeAds.ToString())
        {
            FindObjectOfType<AdsScript>().SetCanShowNoRewardAds(false);
        }
    }
    public void PurchaseSucces(string id) //result from js
    {
        _rewardAction?.Invoke();
        _rewardAction = null;
    }
    public void TryBuy(YandexPurchaseItemId item, Action rewardAction)
    {
        _rewardAction = rewardAction;
        if (TestMode.Value == false)
        {
            Purchase(item.ToString());
        }
        else
        {
            PurchaseSucces(null);
        }
    }
}
