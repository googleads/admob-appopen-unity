using GoogleMobileAds.Api;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public void Start()
    {
        // COMPLETE: Request an app open ad.
        AppOpenAdManager.Instance.LoadAd();
    }

    public void OnApplicationPause(bool paused)
    {
        if (!paused)
        {
            // COMPLETE: Show an app open ad if available.
            AppOpenAdManager.Instance.ShowAdIfAvailable();
        }
    }
}
