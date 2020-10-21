using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class reklamscript : MonoBehaviour
{   private BannerView reklam;
private InterstitialAd Intereklam;
public string BannerID = "	ca-app-pub-3940256099942544/2934735716";
public string InterID = "ca-app-pub-3940256099942544/4411468910";

 
    void Start()
    {
        MobileAds.Initialize(reklamver => {});
        bannereklam();
        InterStatil();
    }

    public void bannereklam()
    {
      reklam = new BannerView(BannerID,AdSize.SmartBanner,AdPosition.Bottom);
      AdRequest yenireklam = new AdRequest.Builder().Build();
      reklam.LoadAd(yenireklam);
    }
public void InterStatil()
{
Intereklam = new InterstitialAd(InterID);
 AdRequest yenireklam = new AdRequest.Builder().Build();
 reklam.LoadAd(yenireklam);
 reklam.Show();
}
   
}
