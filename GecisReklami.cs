using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine;
using System;


public class GecisReklami : MonoBehaviour


{


#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
  private string _adUnitId = "unused";
#endif



    int reklamciksinmi;
    private InterstitialAd gercekreklam;
    public GameObject reklambutonu;
    


    public void Start()
    {
        LoadInterstitialAd();

    
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {

        });


        if (PlayerPrefs.HasKey("reklamciksinmi"))
        {

            reklamciksinmi = PlayerPrefs.GetInt("reklamciksinmi");
            PlayerPrefs.SetInt("reklamciksinmi", reklamciksinmi);

        }
        else
        {
            PlayerPrefs.SetInt("reklamciksinmi", 0);

        }



        if (reklamciksinmi >= 5)

        {
            Invoke("acilsusamacil", 3f);
            
        }



    }


    public void acilsusamacil ()
    
    {
        reklambutonu.SetActive(true);
    }


    public void LoadInterstitialAd()
    {
       

        if (gercekreklam != null)
        {
            gercekreklam.Destroy();
            gercekreklam = null;
        }

        Debug.Log("Loading the interstitial ad.");



        var adRequest = new AdRequest.Builder()
                  .AddKeyword("unity-admob-sample")
                  .Build();

  
        InterstitialAd.Load(_adUnitId, adRequest,
        (InterstitialAd ad, LoadAdError error) =>
        {
            

            if (error != null || ad == null)
            {
                Debug.LogError("interstitial ad failed to load an ad " +
                               "with error : " + error);
                return;
            }

            Debug.Log("Interstitial ad loaded with response : "
                      + ad.GetResponseInfo());

            gercekreklam = ad;
        });
    }


    public void ShowInterstitialAd()
    {

        if (gercekreklam != null && gercekreklam.CanShowAd())

        {

            Debug.Log("Showing interstitial ad.");
            gercekreklam.Show();

        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }

        Invoke("kapat", 1f);

    }



    public void kapat()
   
    {

    Destroy(reklambutonu);

    }


    public void yoket()

    {

     gercekreklam.Destroy();


    }

    
}
