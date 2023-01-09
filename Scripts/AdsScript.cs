using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices; //need to call js

public class AdsScript : MonoBehaviour
{
    private bool _canShowNoRewardAds = true;
    private float _noRewardAdsTime = 200;
    private float _timer;

    public enum Placements 
    {
        Rewarded
    }


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
        if (_timer >= 0)
        {

            _timer -= Time.deltaTime;
        }
    }
    public void ShowAd(Placements placement)
    {
        ShowRewardAd(placement.ToString());

    }
    public void ShowNonRewardAd()
    {
        if (_canShowNoRewardAds && _timer < 0)
        {
            ShowInterstitialAd();
        }
    }
    public void OnNonRewardAdsShowed()
    {
        _timer = _noRewardAdsTime;
    }
    public void OnAdsReward(string placement)
    {
        if (placement == Placements.Rewarded.ToString())
        {
            //reward
        }
    }
    public void OnAdsError()
    {
        SetTimeScale(1);
    }
    public void OnAdsOpen()
    {

        SetTimeScale(0);
    }
    public void OnAdsClose()
    {
        SetTimeScale(1);
    }
    private void SetTimeScale(float val)
    {
        Time.timeScale = val;
        AudioListener.volume = val;
    }
    public void SetCanShowNoRewardAds(bool val)
    {
        _canShowNoRewardAds = val;
    }
}