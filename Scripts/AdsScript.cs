using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices; //need to call js

public class AdsScript : MonoBehaviour
{
    private string _rewardPlacement = "rewardedVideo";
    private bool _canShowNoRewardAds = true;
    private float _noRewardAdsTime = 200;
    private float _timer;


    [DllImport("__Internal")]
    private static extern void ShowRewardAd(string id); //call js from plugin UnityScriptToJS.jslib
    [DllImport("__Internal")]
    private static extern void ShowInterstitialAd(); //call js from plugin UnityScriptToJS.jslib
    private void Start()
    {
        _timer = _noRewardAdsTime;
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
    public void ShowAd(string placement)
    {
        ShowRewardAd(placement);
    }
    public void ShowNonRewardAd()
    {
        if (_canShowNoRewardAds)
        {
            ShowInterstitialAd();
        }
    }
    public void NonRewardAdsShowed()
    {
        _timer = _noRewardAdsTime;
    }
    public void Reward(string placement)
    {
        if (placement == _rewardPlacement)
        {
            //reward
        }
    }

    public void SetCanShowNoRewardAds(bool val)
    {
        _canShowNoRewardAds = val;
    }
}