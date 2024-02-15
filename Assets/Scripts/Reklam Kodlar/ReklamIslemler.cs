using GoogleMobileAds.Api;
using UnityEngine;

public class ReklamIslemler : MonoBehaviour
{
    #region Test Reklamlar�
    /*
        GE��� REKLAMI
    -ANDRO�D =>ca-app-pub-3940256099942544/1033173712
    -�OS => ca-app-pub-3940256099942544/4411468910
    //----------------------------------------------------------
    �D�LL� REKLAM
    -ANDRO�D => ca-app-pub-3940256099942544/5224354917
    -�OS =>  ca-app-pub-3940256099942544/1712485313
    //----------------------------------------------------------
    �D�LL� GE��� REKLAM
    -ANDRO�D => ca-app-pub-3940256099942544/5354046379
    -�OS =>  ca-app-pub-3940256099942544/6978759866
    //----------------------------------------------------------
    BANNER REKLAM
    -ANDRO�D => ca-app-pub-3940256099942544/6300978111
    -�OS =>  ca-app-pub-3940256099942544/2934735716
    */
    #endregion

    // uygulama kimli�i-> ca-app-pub-8955636390645831~4603973309 

    // banner reklam->    ca-app-pub-8955636390645831/1762450873
    
    // ge�i� reklam->     ca-app-pub-8955636390645831/9599728239

    // �d�ll� reklam->    ca-app-pub-8955636390645831/7903503180

    // �d�ll� ge�i� reklam-> ca-app-pub-8955636390645831/1721238216

    #region Reklam Kimli�i
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
            Debug.Log("Banmner Y�klendi");
        };
        bannerReklami.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.Log("Banner Y�klenmedi. Hata: " + error);
            BannerReklamiYukle();
        };
    }

    #endregion

    #region Odullu Gecis Reklami

    public void OdulluGecisReklamiGoster()
    {
        const string odulMesaji = "Odull� Ge�i� Kazan�ld�! �r�n: {0},De�er {1}";

        if (odulluGecisReklami != null && odulluGecisReklami.CanShowAd())
        {
            odulluGecisReklami.Show((Reward reward) =>
            {
                Debug.Log(string.Format(odulMesaji, reward.Type, reward.Amount));
            });
        }
        else
        {
            Debug.Log("�d�ll� Reklam Haz�r De�il");
        }
    }
    void OdulluGecisReklamiOlustur()
    {

        if (odulluGecisReklami != null)
        {
            odulluGecisReklami.Destroy();
            odulluGecisReklami = null;
        }
        Debug.Log("Reklam Y�klendi");

        var ReklamIstek = new AdRequest.Builder().Build();

        RewardedInterstitialAd.Load(odulluGecisReklamID, ReklamIstek,
            (RewardedInterstitialAd Ad, LoadAdError error) =>
            {
                if (error != null || Ad == null)
                {
                    Debug.LogError("�d�ll� Reklam Y�klenirken Hata Olu�tu: " + error);
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
            Debug.Log(string.Format("�d�ll� Ge�i� Reklam� {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };

        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("�d�ll� Ge�i� Reklam� G�sterildi.");
        };

        ad.OnAdClicked += () =>
        {
            Debug.Log("�d�ll� Ge�i� Reklam� T�kland�.");
        };

        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("�d�ll� Ge�i� Reklam� Tam Ekran A��ld�.");
        };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("�d�ll� Ge�i� Reklam� Kapat�ld�.");
            OdulluGecisReklamiOlustur();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("�d�ll� Ge�i� Reklam� Tam Ekran A��lamad�: " + error);
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
        const string odulMesaji = "Odul Kazan�ld�. �r�n: {0},De�er {1}";

        if (odulluReklam != null && odulluReklam.CanShowAd())
        {
            odulluReklam.Show((Reward reward) =>
            {
                Debug.Log(string.Format(odulMesaji, reward.Type, reward.Amount));
            });
        }
        else
        {
            Debug.Log("�d�ll� Reklam Haz�r De�il");
        }
    }
    void OdulluReklamOlustur()
    {

        if (odulluReklam != null)
        {
            odulluReklam.Destroy();
            odulluReklam = null;
        }
        Debug.Log("Reklam Y�klendi");

        var ReklamIstek = new AdRequest.Builder().Build();

        RewardedAd.Load(odulluReklamID, ReklamIstek,
            (RewardedAd Ad, LoadAdError error) =>
            {
                if (error != null || Ad == null)
                {
                    Debug.LogError("�d�ll� Reklam Y�klenirken Hata Olu�tu: " + error);
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
            Debug.Log(string.Format("�d�ll� Reklam� {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };

        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("�d�ll� Reklam� G�sterildi.");
        };

        ad.OnAdClicked += () =>
        {
            Debug.Log("�d�ll� Reklam� T�kland�.");
        };

        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("�d�ll� Reklam� Tam Ekran A��ld�.");
        };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("�d�ll� Reklam� Kapat�ld�.");
            OdulluReklamOlustur();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("�d�ll� Reklam� Tam Ekran A��lamad�: " + error);
            OdulluReklamOlustur();
        };

    }
    void OdulluReklamiYokEt()
    {
        odulluReklam.Destroy();
    }
    #endregion

    #region Gecis Reklam�
    void GecisReklamiOlustur()
    {

        if (gecisReklami != null)
        {
            gecisReklami.Destroy();
            gecisReklami = null;
        }
        Debug.Log("Reklam Y�klendi");

        var ReklamIstek = new AdRequest.Builder().Build();

        InterstitialAd.Load(gecisReklamID, ReklamIstek,
            (InterstitialAd Ad, LoadAdError error) =>
            {
                if (error != null || Ad == null)
                {
                    Debug.LogError("Reklam Y�klenirken Hata Olu�tu: " + error);
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
            Debug.Log(string.Format("Ge�i� Reklam� {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };

        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Ge�i� Reklam� G�sterildi.");
        };

        ad.OnAdClicked += () =>
        {
            Debug.Log("Ge�i� Reklam� T�kland�.");
        };

        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Ge�i� Reklam� Tam Ekran A��ld�.");
        };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Ge�i� Reklam� Kapat�ld�.");
            GecisReklamiOlustur();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("Ge�i� Reklam� Tam Ekran A��lamad�: " + error);
            GecisReklamiOlustur();
        };

    }

    public void GecisReklamiGoster()
    {
        if (gecisReklami != null && gecisReklami.CanShowAd())
        {
            gecisReklami.Show();
            Debug.Log("Reklam G�sterildi");
        }
        else
        {
            Debug.Log("Ge�i� Reklam� Hen�z Haz�r De�il");
        }
    }

    void GecisReklamiYokEt()
    {
        gecisReklami.Destroy();
    }

    #endregion
}