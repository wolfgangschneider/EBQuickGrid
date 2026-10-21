using System.Runtime.CompilerServices;

namespace EBQuickGridLib;

internal static class EBQuickGridModuleInit
{
    // Renders the column headers as <button> instead of <a href>, so that sorting goes through
    // SortByColumnAsync/NavigateTo, which SilentNavigationManager can intercept.
#pragma warning disable CA2255
    [ModuleInitializer]
#pragma warning restore CA2255
    internal static void DisableUrlBasedQuickGridNavigationAndSorting() =>
        AppContext.SetSwitch("Microsoft.AspNetCore.Components.QuickGrid.EnableUrlBasedQuickGridNavigationAndSorting", false);
}
