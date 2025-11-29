using AngleSharp.Dom;
using LMS.Components.Source.UI.Button;
using TailwindMerge.Extensions;

namespace LMS.Components.Tests.Tests;

public class ButtonTests : BunitContext
{
    public ButtonTests()
    {
        Services.AddTailwindMerge();
    }

    [Theory]
    [InlineData(ButtonType.Button, "button")]
    [InlineData(ButtonType.Reset, "reset")]
    [InlineData(ButtonType.Submit, "submit")]
    public void HtmlType_AppliedCorrectly(ButtonType type, string expectedHtmlType)
    {
        // Arrange
        IRenderedComponent<Button> component = Render<Button>(parameters => parameters
            .Add(p => p.Type, type)
        );

        // Assert
        IElement buttonElement = component.Find("button");
        buttonElement.GetAttribute("type").Should().Be(expectedHtmlType);
    }

    [Fact]
    public void Disabled_AttributeAppliedCorrectly()
    {
        // Arrange
        IRenderedComponent<Button> component = Render<Button>(parameters => parameters
            .Add(p => p.Disabled, true)
        );

        // Assert
        IElement buttonElement = component.Find("button");
        buttonElement.HasAttribute("disabled").Should().BeTrue();
    }

    [Fact]
    public void Link_AttributeChangeButtonToATag()
    {
        // Arrange
        const string link = "/link";
        IRenderedComponent<Button> component = Render<Button>(parameters => parameters
            .Add(p => p.Link, link)
        );

        // Assert
        IElement buttonElement = component.Find("a");
        buttonElement.Attributes["href"]?.Value.Should().Be(link);
    }

    [Fact]
    public void AdditionalAttributes_ShouldBeAppliedToATag()
    {
        // Arrange
        const string target = "_blank";
        IRenderedComponent<Button> component = Render<Button>(parameters => parameters
            .Add(p => p.Link, "/link")
            .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "target", target } })
        );

        // Assert
        IElement buttonElement = component.Find("a");
        buttonElement.Attributes["target"]?.Value.Should().Be(target);
    }
}