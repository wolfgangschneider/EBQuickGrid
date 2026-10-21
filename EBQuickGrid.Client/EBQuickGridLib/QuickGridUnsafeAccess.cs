using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace EBQuickGridLib;

internal static class QuickGridUnsafeAccess<TGridItem> where TGridItem : class
{
    // QuickGrid<TGridItem>'s own [Inject] private NavigationManager: access via the generated accessors.
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_NavigationManager")]
    public static extern NavigationManager Get_NavigationManager(QuickGrid<TGridItem> instance);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_NavigationManager")]
    public static extern void Set_NavigationManager(QuickGrid<TGridItem> instance, NavigationManager value);
}
