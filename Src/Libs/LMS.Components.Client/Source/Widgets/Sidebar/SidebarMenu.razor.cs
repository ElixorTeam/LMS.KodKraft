using Blazor.Heroicons;
using LMS.Components.Client.Source.Shared.Constants;
using Microsoft.AspNetCore.Components;

namespace LMS.Components.Client.Source.Widgets.Sidebar;

#region Records

public record NavMenuItemModel(string Name, string Link);
public record MenuSection(string Label, string Icon, NavMenuItemModel[] Items);

#endregion

public sealed partial class SidebarMenu : ComponentBase
{
    // [Inject] private IStringLocalizer<ApplicationResources> Localizer { get; set; } = default!;
    private IEnumerable<MenuSection> MenuSections { get; set; } = [];

    protected override void OnInitialized()
    {
        MenuSections = CreateNavMenus();
    }

    private IEnumerable<MenuSection> CreateNavMenus() =>
    [
        new("Сomponents", HeroiconName.ComputerDesktop, [
            new("Button", Urls.Button),
            new("Badge", Urls.Badge),
            new("Other", Urls.Other)
        ]),
    ];
}
