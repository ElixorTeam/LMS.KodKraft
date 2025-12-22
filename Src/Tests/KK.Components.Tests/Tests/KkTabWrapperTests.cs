using AngleSharp.Dom;

namespace KK.Components.Tests.Tests;

public class KkTabWrapperTests : BunitContext
{
    [Fact]
    public void Tabs_ShouldHandleEmptyActiveTabId()
    {
        // Arrange
        IRenderedComponent<KkTabWrapper> cut = Render<KkTabWrapper>(parameters => parameters
            .AddChildContent<KkTabItem>(p => p.Add(t => t.Id, "first").Add(t => t.ChildContent, "<p>First tab</p>"))
            .AddChildContent<KkTabItem>(p => p.Add(t => t.Id, "second").Add(t => t.ChildContent, "<p>Second tab</p>"))
        );

        // Act
        string activeTabId = cut.Instance.ActiveTabId;

        // Assert
        activeTabId.Should().NotBeEmpty();
    }

    [Fact]
    public void Tabs_ShouldShowsCorrectContentOfActiveTab()
    {
        // Arrange
        IRenderedComponent<KkTabWrapper> cut = Render<KkTabWrapper>(parameters => parameters
            .AddChildContent<KkTabItem>(p => p.Add(t => t.Id, "first").Add(t => t.ChildContent, "<p>First tab</p>"))
            .AddChildContent<KkTabItem>(p => p.Add(t => t.Id, "second").Add(t => t.ChildContent, "<p>Second tab</p>"))
        );

        // Assert
        IElement tabContent = cut.Find("p");
        tabContent.InnerHtml.Should().Be("First tab");
    }

    [Fact]
    public void DefaultTab_ShouldBeSetCorrectly()
    {
        // Arrange
        IRenderedComponent<KkTabWrapper> cut = Render<KkTabWrapper>(parameters => parameters
            .Add(p => p.DefaultTab, "second")
            .AddChildContent<KkTabItem>(p => p.Add(t => t.Id, "first").Add(t => t.ChildContent, "<p>First tab</p>"))
            .AddChildContent<KkTabItem>(p => p.Add(t => t.Id, "second").Add(t => t.ChildContent, "<p>Second tab</p>"))
        );

        // Act
        string activeTabId = cut.Instance.ActiveTabId;

        // Assert
        activeTabId.Should().Be("second");
    }

    [Fact]
    public async Task ChangeTabMethod_ShouldChangeActiveTab()
    {
        // Arrange
        IRenderedComponent<KkTabWrapper> cut = Render<KkTabWrapper>(parameters => parameters
            .AddChildContent<KkTabItem>(p => p.Add(t => t.Id, "first").Add(t => t.ChildContent, "<p>First tab</p>"))
            .AddChildContent<KkTabItem>(p => p.Add(t => t.Id, "second").Add(t => t.ChildContent, "<p>Second tab</p>"))
        );

        // Act
        await cut.InvokeAsync(() => cut.Instance.ChangeTab("second"));

        // Assert
        cut.Instance.ActiveTabId.Should().Be("second");
    }

    [Fact]
    public void SettingActiveTabId_ShouldChangeActiveTab()
    {
        // Arrange
        IRenderedComponent<KkTabWrapper> cut = Render<KkTabWrapper>(parameters => parameters
            .Add(p => p.ActiveTabId, "second")
            .AddChildContent<KkTabItem>(p => p.Add(t => t.Id, "first").Add(t => t.ChildContent, "<p>First tab</p>"))
            .AddChildContent<KkTabItem>(p => p.Add(t => t.Id, "second").Add(t => t.ChildContent, "<p>Second tab</p>"))
        );

        // Act
        string activeTabId = cut.Instance.ActiveTabId;

        // Assert
        activeTabId.Should().Be("second");
    }

    // [Fact]
    // public void Tabs_ShouldBeRegisteredInCorrectOrder()
    // {
    //     // Arrange
    //     IRenderedComponent<Tabs> cut = Render<Tabs>(parameters => parameters
    //         .AddChildContent<Tab>(p => p.Add(t => t.Id, "first").Add(t => t.ChildContent, "<p>First tab</p>"))
    //         .AddChildContent<Tab>(p => p.Add(t => t.Id, "second").Add(t => t.ChildContent, "<p>Second tab</p>"))
    //     );
    //
    //     // Act
    //     List<Tab> tabs = cut.Instance.TabsList;
    //
    //     // Assert
    //     tabs.Should().HaveCount(2);
    //     tabs[0].Id.Should().Be("first");
    //     tabs[1].Id.Should().Be("second");
    // }

    // [Fact]
    // public void Tab_ShouldRegisterIdAndLabelCorrectly()
    // {
    //     // Arrange
    //     IRenderedComponent<Tabs> cut = Render<Tabs>(parameters => parameters
    //         .AddChildContent<Tab>(p => p.Add(t => t.Id, "first").Add(t => t.Label, "First Tab").Add(t => t.ChildContent, "<p>First tab</p>"))
    //         .AddChildContent<Tab>(p => p.Add(t => t.Id, "second").Add(t => t.Label, "Second Tab").Add(t => t.ChildContent, "<p>Second tab</p>"))
    //     );
    //
    //     // Act
    //     List<Tab> tabs = cut.Instance.TabsList;
    //
    //     // Assert
    //     tabs.Should().HaveCount(2);
    //     tabs[0].Id.Should().Be("first");
    //     tabs[0].Label.Should().Be("First Tab");
    //     tabs[1].Id.Should().Be("second");
    //     tabs[1].Label.Should().Be("Second Tab");
    // }
    //
    //
    // [Fact]
    // public void Tabs_ShouldBeUnregisteredWhenRemovedFromMarkup()
    // {
    //     // Arrange
    //     IRenderedComponent<Tabs> cut = Render<Tabs>(parameters => parameters
    //         .AddChildContent<Tab>(p => p.Add(t => t.Id, "first").Add(t => t.ChildContent, "<p>First tab</p>"))
    //         .AddChildContent<Tab>(p => p.Add(t => t.Id, "second").Add(t => t.ChildContent, "<p>Second tab</p>"))
    //     );
    //
    //     // Act
    //     cut.SetParametersAndRender(parameters => parameters.AddChildContent<Tab>(p => p.Add(t => t.Id, "second").Add(t => t.ChildContent, "<p>Second tab</p>")));
    //     List<Tab> tabs = cut.Instance.TabsList;
    //
    //     // Assert
    //     tabs.Should().HaveCount(1);
    //     tabs[0].Id.Should().Be("second");
    // }
    //
    // [Fact]
    // public void Tabs_ShouldHandleDuplicateLabels()
    // {
    //     // Arrange
    //     IRenderedComponent<Tabs> cut = RenderComponent<Tabs>(parameters => parameters
    //         .AddChildContent<Tab>(p => p.Add(t => t.Id, "first").Add(t => t.Label, "Duplicate").Add(t => t.ChildContent, "<p>First tab</p>"))
    //         .AddChildContent<Tab>(p => p.Add(t => t.Id, "second").Add(t => t.Label, "Duplicate").Add(t => t.ChildContent, "<p>Second tab</p>"))
    //     );
    //
    //     // Act
    //     List<Tab> tabs = cut.Instance.TabsList;
    //
    //     // Assert
    //     tabs.Count.Should().Be(2);
    //     tabs[0].Label.Should().Be("Duplicate");
    //     tabs[1].Label.Should().Be("Duplicate");
    // }
}