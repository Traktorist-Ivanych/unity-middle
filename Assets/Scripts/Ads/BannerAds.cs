using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    [SerializeField] private BannerPosition bannerPosition;
    [SerializeField] private string androidAdsID = "Banner_Android";
    [SerializeField] private string iOSAdsID = "Banner_iOS";

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

        Advertisement.Banner.SetPosition(bannerPosition);
        LoadBanner();
    }

    public void LoadBanner()
    {
        BannerLoadOptions bannerLoadOptions = new BannerLoadOptions
        {
            errorCallback = OnBannerLoadError,
            loadCallback = OnBannerLoad
        };

        Advertisement.Banner.Load(adsID, bannerLoadOptions);
    }

    private void OnBannerLoadError(string message)
    {
        Debug.LogError("Banner load error: " + message);
    }

    private void OnBannerLoad()
    {
        Debug.Log("Banner Loaded");
        ShowBanner();
    }

    public void ShowBanner()
    {
        BannerOptions bannerLoadOptions = new BannerOptions
        {
            clickCallback = OnBannerClick,
            hideCallback = OnBannerHide,
            showCallback = OnBannerShow
        };

        Advertisement.Banner.Show(adsID, bannerLoadOptions);
    }

    private void OnBannerClick()
    {

    }

    private void OnBannerHide()
    {

    }

    private void OnBannerShow()
    {
        Debug.Log("Banner showing");
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide(false);
    }
}
