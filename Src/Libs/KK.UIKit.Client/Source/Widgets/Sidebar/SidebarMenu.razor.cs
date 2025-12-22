using Blazor.Heroicons;
using KK.UIKit.Client.Source.Shared.Constants;
using Microsoft.AspNetCore.Components;

namespace KK.UIKit.Client.Source.Widgets.Sidebar;

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
        new("Foundation", HeroiconName.Swatch, [
            new("Colors", Urls.Color),
        ]),
        new("Сomponents", HeroiconName.RectangleStack, [
            new("Button", Urls.Button),
            new("Badge", Urls.Badge),
            new("Dropdown", Urls.Dropdown),
            new("Accordion", Urls.Accordion),
            new("Tabs", Urls.Tab),
            new("Other", Urls.Other)
        ]),
        new("Form",HeroiconName.Bookmark, [
            new("Inputs", Urls.Input),
            new("Booleans", Urls.Bool),
        ]),
    ];
}
