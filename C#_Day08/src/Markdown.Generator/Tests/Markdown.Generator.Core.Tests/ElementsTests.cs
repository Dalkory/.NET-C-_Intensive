using Markdown.Generator.Core.Markdown.Elements;

namespace Markdown.Generator.Core.Tests;

public class ElementsTests
{
    [Fact]
    public void Given_Code_When_LanguageAndCodeAsParameter_Then_ReturnMarkdownCodeMarkup()
    {
        string expected = "```csharp\nsome code\n```\n";
        Code codeElement = new Code("csharp", "some code");
        string actual = codeElement.Create();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Given_CodeQuote_When_QuoteAsParameter_Then_ReturnMarkdownCodeQuoteMarkup()
    {
        string expected = "```quote```";
        CodeQuote codeQuoteElement = new CodeQuote("quote");
        string actual = codeQuoteElement.Create();
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Given_Header_When_LevelAndTextAsParameter_Then_ReturnMarkdownHeaderMarkup()
    {
        string expected = "# Header Text\n";
        Header headerElement = new Header(2, "Header Text");
        string actual = headerElement.Create();
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Given_List_When_TextAsParameter_Then_ReturnMarkdownListMarkup()
    {
        string expected = "- List Item\n";
        List listElement = new List("List Item");
        string actual = listElement.Create();
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Given_Link_When_TitleAndUrlAsParameters_Then_ReturnMarkdownLinkMarkup()
    {
        string expected = "[Link Text](http://example.com)";
        Link linkElement = new Link("Link Text", "http://example.com");
        string actual = linkElement.Create();
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Given_Image_When_TitleAndUrlAsParameters_Then_ReturnMarkdownImageMarkup()
    {
        string expected = "![Image Alt](http://example.com/image.jpg)";
        Image imageElement = new Image("Image Alt", "http://example.com/image.jpg");
        string actual = imageElement.Create();
        Assert.Equal(expected, actual);
    }
}