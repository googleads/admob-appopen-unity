using GoogleMobileAds.Api;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public void Start()
    {
        MobileAds.Initialize((initStatus) => { AppOpenAdManager.Instance.LoadAd(); });
    }

    public void OnApplicationPause(bool paused)
    {
        if (!paused)
        {
            AppOpenAdManager.Instance.ShowAdIfAvailable();
        }
    }
}
