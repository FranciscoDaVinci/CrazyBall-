using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsInterstitial : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    Action _onComplete;
    public void StartLoadInterstitial()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(AdsManager.interstitialAndroid, this);
        }
    }
    public void ShowInterstitial(Action onComplete = null)
    {
        _onComplete = onComplete;
        if (!Advertisement.isInitialized)
        {
            CompleteInterstitial();
            return;
        }
        Advertisement.Show(AdsManager.interstitialAndroid, this);
    }
    void CompleteInterstitial()
    {
        _onComplete?.Invoke();
        _onComplete = null;
    }
    void IUnityAdsLoadListener.OnUnityAdsAdLoaded(string placementId)
    {
    }
    void IUnityAdsLoadListener.OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Interstitial no cargado: " + message);
    }
    void IUnityAdsShowListener.OnUnityAdsShowClick(string placementId)
    {
    }
    void IUnityAdsShowListener.OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        CompleteInterstitial();
        StartLoadInterstitial();
    }
    void IUnityAdsShowListener.OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Interstitial error: " + message);
        CompleteInterstitial();
        StartLoadInterstitial();
    }
    void IUnityAdsShowListener.OnUnityAdsShowStart(string placementId)
    {
    }
}
