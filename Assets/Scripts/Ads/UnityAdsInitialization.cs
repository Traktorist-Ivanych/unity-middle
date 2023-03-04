using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsInitialization : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameID;
    [SerializeField] private string iOSGameID;
    [SerializeField] private bool testMode;

    private string gameID;

    private void Awake()
    {
        InitializeUnityADS();
    }

    private void InitializeUnityADS()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            gameID = iOSGameID;
        }
        else
        {
            gameID = androidGameID;
        }
        Advertisement.Initialize(gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity ADS Initialization Complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError("Unity ADS initialization is not complete. " + error.ToString() + " " + message);
    }
}
