using AngleSharp.Dom;
using TailwindMerge.Extensions;

namespace KK.Components.Tests.Tests;

public class ButtonTests : BunitContext
{
    public ButtonTests()
    {
        Services.AddTailwindMerge();
    }

    [Theory]
    [InlineData(BtnType.Button, "button")]
    [InlineData(BtnType.Reset, "reset")]
    [InlineData(BtnType.Submit, "submit")]
    public void HtmlType_AppliedCorrectly(BtnType type, string expectedHtmlType)
    {
        // Arrange
        IRenderedComponent<KkButton> component = Render<KkButton>(parameters => parameters
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
        IRenderedComponent<KkButton> component = Render<KkButton>(parameters => parameters
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
        IRenderedComponent<KkButton> component = Render<KkButton>(parameters => parameters
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
        IRenderedComponent<KkButton> component = Render<KkButton>(parameters => parameters
            .Add(p => p.Link, "/link")
            .Add(p => p.AdditionalAttributes, new Dictionary<string, object> { { "target", target } })
        );

        // Assert
        IElement buttonElement = component.Find("a");
        buttonElement.Attributes["target"]?.Value.Should().Be(target);
    }
}