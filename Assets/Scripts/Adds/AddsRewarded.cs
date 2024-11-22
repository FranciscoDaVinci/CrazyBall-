using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsRewarded : MonoBehaviour,IUnityAdsLoadListener, IUnityAdsShowListener
{
    public void StartLoadRewarded()
    {
        Advertisement.Load(AdsManager.rewardedAndroid, this);
    }

    public void ShowRewarded()
    {
        Advertisement.Show(AdsManager.rewardedAndroid, this);
    }

    void IUnityAdsLoadListener.OnUnityAdsAdLoaded(string placementId)
    {
        
    }

    void IUnityAdsLoadListener.OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        
    }
    


    void IUnityAdsShowListener.OnUnityAdsShowClick(string placementId)
    {
        
    }

    void IUnityAdsShowListener.OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        switch (showCompletionState)
        {
            case UnityAdsShowCompletionState.SKIPPED:
                Debug.Log("Recompensa Skpieada");
                break;
            case UnityAdsShowCompletionState.COMPLETED:
                Debug.Log("Recompensa Completada");
                break;
            case UnityAdsShowCompletionState.UNKNOWN:
                Debug.Log("Recompensa Error");
                break;
        }
    }

    void IUnityAdsShowListener.OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }

    void IUnityAdsShowListener.OnUnityAdsShowStart(string placementId)
    {
        
    }
}
