using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private StoreShopping storeShopping;
    [SerializeField] private string androidAdsID = "Rewarded_Android";
    [SerializeField] private string iOSAdsID = "Rewarded_iOS";

    private string adsID;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            adsID = iOSAdsID;
        }
        else
        {
            adsID = androidAdsID;
        }

        LoadAds();
    }

    public void LoadAds()
    {
        Debug.Log("Loading Ad: " + adsID);
        Advertisement.Load(adsID, this);
    }

    public void ShowAds()
    {
        Debug.Log("Loading Ad: " + adsID);
        Advertisement.Show(adsID, this);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(adsID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Rewarded Ad show complited");
            storeShopping.OnPurchaseComplited(50);
            LoadAds();
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad loaded: " + adsID);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError("Load error: " + error.ToString() + ". " + message);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError("Show error: " + error.ToString() + ". " + message);
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Ad Show Start");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Ad Show Click");
    }
}
