using Android.App;
using Android.OS;
using Android.Widget;
using Com.Revenuecat.Purchases;
using Com.Revenuecat.Purchases.Common.Subscriberattributes;

namespace Tonestro.Maui.RevenueCat.Android.UsageChecker;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        Purchases.LogLevel = LogLevel.Debug;
        Purchases.Configure(new PurchasesConfiguration.Builder(this, "apikey").Build());
        string revenueCatVersion = Purchases.FrameworkVersion;

        var txtRevenueCatVersion = FindViewById<TextView>(Resource.Id.txtRevenueCatVersion);

        var txtAdjustNetwork = FindViewById<TextView>(Resource.Id.txtAdjustNetwork);

        txtRevenueCatVersion.Text = $"RevenueCat {revenueCatVersion}";

        string adjustNetwork = SubscriberAttributeKey.AttributionIds.Adjust.Instance.BackendKey;
        txtAdjustNetwork.Text = adjustNetwork;
    }
}