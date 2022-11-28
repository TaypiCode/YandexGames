using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices; //need to call js

public class ShopScript : MonoBehaviour
{
    private AdsScript _ads;
    private string _removeAdsShopId = "removeAds"; //id add in ya games console shop itemId

    [DllImport("__Internal")]
    private static extern void Purchase(string id); //call js from plugin UnityScriptToJS.jslib
    private void Awake()
    {
        _ads = FindObjectOfType<AdsScript>();
    }
    public void DisableShowAds()
    {
        _ads.SetCanShowNoRewardAds(false);
    }
    public void AlreadyBought(string id) //result from js
    {
        if (id == _removeAdsShopId)
        {
            DisableShowAds();
        }
    }
    public void PurchaseSucces(string id) //result from js
    {
        if(id == _removeAdsShopId)
        {
            DisableShowAds();
        }
    }
    public void TryBuyRemoveAds() //from scene or script
    {
        Purchase(_removeAdsShopId);
    }
}
