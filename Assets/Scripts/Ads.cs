using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Ads : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    [SerializeField] private Button _rewardedButton;

    public static Action onAdsShowComplete;
    
    private bool _isTestMode = true;
    private string _gameID = "4774511";
    private string _rewardedVideoKey = "Rewarded_Android";
    
    private void Awake()
    {
        Advertisement.Load(_rewardedVideoKey, this);
        Advertisement.Initialize(_gameID, _isTestMode,this);
        _rewardedButton.onClick.AddListener(ShowRewardedVideo);
        _rewardedButton.interactable = false;
    }

    private void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardedVideoKey, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId == _rewardedVideoKey)
        {
            _rewardedButton.interactable = true;
        }
    }
    
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            onAdsShowComplete?.Invoke();
        }
    }
    
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
       
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnInitializationComplete()
    {
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
       
    }
}
