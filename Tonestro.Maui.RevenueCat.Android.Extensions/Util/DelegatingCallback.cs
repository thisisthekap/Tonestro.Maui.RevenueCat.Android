using Com.Revenuecat.Purchases.Interfaces;

namespace Tonestro.Maui.RevenueCat.Android.Extensions.Util;

public class DelegatingCallback<TResult> : DelegatingListenerBase<TResult>, ICallback
{
    public DelegatingCallback(CancellationToken cancellationToken) : base(cancellationToken)
    {
    }

    public void OnReceived(Java.Lang.Object? resultObject)
    {
        if (resultObject is TResult result)
        {
            ReportSuccess(result);
        }
        else
        {
            ReportException(
                new System.Exception($"{resultObject?.GetType().Name} is not a {typeof(TResult).Name}"));
        }
    }
}