using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace EBQuickGridLib;

/// <summary>
/// A <see cref="QuickGrid{TGridItem}"/> that never writes sort/page state to the URL (query parameters).
/// </summary>
[CascadingTypeParameter(nameof(TGridItem))]
public class EBQuickGrid<TGridItem> : QuickGrid<TGridItem> where TGridItem : class
{
    /// <inheritdoc />
    protected override async Task OnParametersSetAsync()
    {
        // must be replaced before base.OnParametersSetAsync(): that is where QuickGrid reads from / writes to the URL
        var current = QuickGridUnsafeAccess<TGridItem>.Get_NavigationManager(this);
        if (current is not SilentNavigationManager)
            QuickGridUnsafeAccess<TGridItem>.Set_NavigationManager(this, new SilentNavigationManager(current));

        await base.OnParametersSetAsync();
    }
}
