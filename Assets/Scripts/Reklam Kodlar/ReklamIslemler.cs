using GoogleMobileAds.Api;
using UnityEngine;

public class ReklamIslemler : MonoBehaviour
{
    #region Test Reklamlarý
    /*
        GEÇÝÞ REKLAMI
    -ANDROÝD =>ca-app-pub-3940256099942544/1033173712
    -ÝOS => ca-app-pub-3940256099942544/4411468910
    //----------------------------------------------------------
    ÖDÜLLÜ REKLAM
    -ANDROÝD => ca-app-pub-3940256099942544/5224354917
    -ÝOS =>  ca-app-pub-3940256099942544/1712485313
    //----------------------------------------------------------
    ÖDÜLLÜ GEÇÝÞ REKLAM
    -ANDROÝD => ca-app-pub-3940256099942544/5354046379
    -ÝOS =>  ca-app-pub-3940256099942544/6978759866
    //----------------------------------------------------------
    BANNER REKLAM
    -ANDROÝD => ca-app-pub-3940256099942544/6300978111
    -ÝOS =>  ca-app-pub-3940256099942544/2934735716
    */
    #endregion

    // uygulama kimliði-> ca-app-pub-8955636390645831~4603973309 

    // banner reklam->    ca-app-pub-8955636390645831/1762450873
    
    // geçiþ reklam->     ca-app-pub-8955636390645831/9599728239

    // ödüllü reklam->    ca-app-pub-8955636390645831/7903503180

    // ödüllü geçiþ reklam-> ca-app-pub-8955636390645831/1721238216

    #region Reklam Kimliði
#if UNITY_EDITOR
    string gecisReklamID = "ca-app-pub-3940256099942544/1033173712";
    string odulluReklamID = "ca-app-pub-3940256099942544/5224354917";
    string odulluGecisReklamID = "ca-app-pub-3940256099942544/5354046379";
    string bannerReklamID = "ca-app-pub-3940256099942544/6300978111";

#elif UNITY_ANDROID
    string gecisReklamID = "ca-app-pub-3940256099942544/1033173712";
    string odulluReklamID = "ca-app-pub-3940256099942544/5224354917";
    string odulluGecisReklamID = "ca-app-pub-3940256099942544/5354046379";
    string bannerReklamID = "ca-app-pub-3940256099942544/6300978111";
#else
    string gecisReklamID = "unused";

#endif

    #endregion

    InterstitialAd gecisReklami;
    RewardedAd odulluReklam;
    RewardedInterstitialAd odulluGecisReklami;
    BannerView bannerReklami;

    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {

        });

        GecisReklamiOlustur();
        OdulluReklamOlustur();
        OdulluGecisReklamiOlustur();
        //BannerReklamiYukle();

    }

    #region Banner Reklami
    void BannerReklamiOlustur()
    {
        if (bannerReklami!=null)
        {
            bannerReklami.Destroy();
            bannerReklami= null;    
        }
        bannerReklami = new BannerView(bannerReklamID, AdSize.Banner, AdPosition.Bottom);

    } 
    void BannerReklamiYukle()
    {
        if (bannerReklami!=null)
        {
            BannerReklamiOlustur();

            var reklamIstegi = new AdRequest.Builder().Build();
            bannerReklami.LoadAd(reklamIstegi);
            ReklamOlaylariniDinle();
        }
    }
    void ReklamOlaylariniDinle()
    {
        bannerReklami.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banmner Yüklendi");
        };
        bannerReklami.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.Log("Banner Yüklenmedi. Hata: " + error);
            BannerReklamiYukle();
        };
    }

    #endregion

    #region Odullu Gecis Reklami

    public void OdulluGecisReklamiGoster()
    {
        const string odulMesaji = "Odullü Geçiþ Kazanýldý! Ürün: {0},Deðer {1}";

        if (odulluGecisReklami != null && odulluGecisReklami.CanShowAd())
        {
            odulluGecisReklami.Show((Reward reward) =>
            {
                Debug.Log(string.Format(odulMesaji, reward.Type, reward.Amount));
            });
        }
        else
        {
            Debug.Log("Ödüllü Reklam Hazýr Deðil");
        }
    }
    void OdulluGecisReklamiOlustur()
    {

        if (odulluGecisReklami != null)
        {
            odulluGecisReklami.Destroy();
            odulluGecisReklami = null;
        }
        Debug.Log("Reklam Yüklendi");

        var ReklamIstek = new AdRequest.Builder().Build();

        RewardedInterstitialAd.Load(odulluGecisReklamID, ReklamIstek,
            (RewardedInterstitialAd Ad, LoadAdError error) =>
            {
                if (error != null || Ad == null)
                {
                    Debug.LogError("Ödüllü Reklam Yüklenirken Hata Oluþtu: " + error);
                    return;
                }
                odulluGecisReklami = Ad;

            });
        ReklamOlayDinle(odulluGecisReklami);
    }
    void ReklamOlayDinle(RewardedInterstitialAd ad)
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Ödüllü Geçiþ Reklamý {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };

        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Ödüllü Geçiþ Reklamý Gösterildi.");
        };

        ad.OnAdClicked += () =>
        {
            Debug.Log("Ödüllü Geçiþ Reklamý Týklandý.");
        };

        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Ödüllü Geçiþ Reklamý Tam Ekran Açýldý.");
        };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Ödüllü Geçiþ Reklamý Kapatýldý.");
            OdulluGecisReklamiOlustur();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("Ödüllü Geçiþ Reklamý Tam Ekran Açýlamadý: " + error);
            OdulluGecisReklamiOlustur();
        };

    }
    void OdulluGecisReklamiYokEt()
    {
        odulluGecisReklami.Destroy();
    }

#endregion

    #region Odullu Reklam
    public void OdulluReklamGoster()
    {
        const string odulMesaji = "Odul Kazanýldý. Ürün: {0},Deðer {1}";

        if (odulluReklam != null && odulluReklam.CanShowAd())
        {
            odulluReklam.Show((Reward reward) =>
            {
                Debug.Log(string.Format(odulMesaji, reward.Type, reward.Amount));
            });
        }
        else
        {
            Debug.Log("Ödüllü Reklam Hazýr Deðil");
        }
    }
    void OdulluReklamOlustur()
    {

        if (odulluReklam != null)
        {
            odulluReklam.Destroy();
            odulluReklam = null;
        }
        Debug.Log("Reklam Yüklendi");

        var ReklamIstek = new AdRequest.Builder().Build();

        RewardedAd.Load(odulluReklamID, ReklamIstek,
            (RewardedAd Ad, LoadAdError error) =>
            {
                if (error != null || Ad == null)
                {
                    Debug.LogError("Ödüllü Reklam Yüklenirken Hata Oluþtu: " + error);
                    return;
                }
                odulluReklam = Ad;

            });
        ReklamOlayDinle(odulluReklam);
    }
    void ReklamOlayDinle(RewardedAd ad)
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Ödüllü Reklamý {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };

        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Ödüllü Reklamý Gösterildi.");
        };

        ad.OnAdClicked += () =>
        {
            Debug.Log("Ödüllü Reklamý Týklandý.");
        };

        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Ödüllü Reklamý Tam Ekran Açýldý.");
        };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Ödüllü Reklamý Kapatýldý.");
            OdulluReklamOlustur();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("Ödüllü Reklamý Tam Ekran Açýlamadý: " + error);
            OdulluReklamOlustur();
        };

    }
    void OdulluReklamiYokEt()
    {
        odulluReklam.Destroy();
    }
    #endregion

    #region Gecis Reklamý
    void GecisReklamiOlustur()
    {

        if (gecisReklami != null)
        {
            gecisReklami.Destroy();
            gecisReklami = null;
        }
        Debug.Log("Reklam Yüklendi");

        var ReklamIstek = new AdRequest.Builder().Build();

        InterstitialAd.Load(gecisReklamID, ReklamIstek,
            (InterstitialAd Ad, LoadAdError error) =>
            {
                if (error != null || Ad == null)
                {
                    Debug.LogError("Reklam Yüklenirken Hata Oluþtu: " + error);
                    return;
                }
                gecisReklami = Ad;

            });
        ReklamOlayDinle(gecisReklami);
    }

    void ReklamOlayDinle(InterstitialAd ad)
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Geçiþ Reklamý {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };

        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Geçiþ Reklamý Gösterildi.");
        };

        ad.OnAdClicked += () =>
        {
            Debug.Log("Geçiþ Reklamý Týklandý.");
        };

        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Geçiþ Reklamý Tam Ekran Açýldý.");
        };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Geçiþ Reklamý Kapatýldý.");
            GecisReklamiOlustur();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("Geçiþ Reklamý Tam Ekran Açýlamadý: " + error);
            GecisReklamiOlustur();
        };

    }

    public void GecisReklamiGoster()
    {
        if (gecisReklami != null && gecisReklami.CanShowAd())
        {
            gecisReklami.Show();
            Debug.Log("Reklam Gösterildi");
        }
        else
        {
            Debug.Log("Geçiþ Reklamý Henüz Hazýr Deðil");
        }
    }

    void GecisReklamiYokEt()
    {
        gecisReklami.Destroy();
    }

    #endregion
}