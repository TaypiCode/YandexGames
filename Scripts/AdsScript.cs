using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices; //need to call js

public class AdsScript : MonoBehaviour
{
    private string _moneyBuffPlacement = "moneyBuff";
    private string _speedBuffPlacement = "speedBuff";
    private float _noRewardAdsTime = 200;
    private float _timer;


    [DllImport("__Internal")]
    private static extern void ShowRewardAd(string id); //call js from plugin AdsScriptToJS.jslib
    [DllImport("__Internal")]
    private static extern void ShowInterstitialAd(); //call js from plugin AdsScriptToJS.jslib

    private void Start()
    {
        _timer = noRewardAdsTime;
    }
    private void Update()
    {
        if (_timer < 0)
        {

            ShowNonRewardAd();
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
    private void ShowAd(string placement)
    {
        ShowRewardAd(placement);
    }
    private void ShowNonRewardAd()
    {
        ShowInterstitialAd();
    }
    public void NonRewardAdsShowed()
    {
        _timer = _noRewardAdsTime;
    }
    public void Reward(string placement)
    {
        if (placement == _moneyBuffPlacement)
        {
            
        }
        else if (placement == _speedBuffPlacement)
        {
            
        }
    }
}
