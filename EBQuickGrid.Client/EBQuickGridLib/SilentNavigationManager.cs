using Microsoft.AspNetCore.Components;

namespace EBQuickGridLib;

// Pretends to be the NavigationManager, but only updates its own Uri/LocationChanged -
// the real browser address bar is never touched.
internal sealed class SilentNavigationManager : NavigationManager
{
    public SilentNavigationManager(NavigationManager realManager) => Initialize(realManager.BaseUri, realManager.Uri);

    protected override void NavigateToCore(string uri, NavigationOptions options)
    {
        // Not a pure no-op: Paginator sets its state only via the LocationChanged return path.
        Uri = uri;
        NotifyLocationChanged(isInterceptedLink: false);
    }
}
