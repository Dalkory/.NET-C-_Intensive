using Markdown.Generator.Core.Markdown;

namespace Markdown.Generator.Core.Tests;

public class Sut
{
    public void PublicMethod() { }
    private void PrivateMethod() { }
    public int PublicField;
    private int PrivateField;
    public int PublicProperty { get; set; }
    private int PrivateProperty { get; set; }
}


public class MarkdownableTypeTests
{
    [Fact]
    public void Given_SutType_When_GetMethodsCalled_Then_OnlyPublicMethodsInElements()
    {
        var sut = new MarkdownableType(typeof(Sut), null);
        var methods = sut.GetMethods();
        Assert.Single(methods);
        Assert.DoesNotContain(methods, x => x.Name == "PrivateMethod");
    }

    [Fact]
    public void Given_SutType_When_GetFieldsCalled_Then_OnlyPublicFieldsInElements()
    {
        var sut = new MarkdownableType(typeof(Sut), null);
        var fields = sut.GetFields();
        Assert.Single(fields);
        Assert.DoesNotContain(fields, x => x.Name == "PrivateField");
    }

    [Fact]
    public void Given_SutType_When_GetPropertiesCalled_Then_OnlyPublicPropertiesInElements()
    {
        var sut = new MarkdownableType(typeof(Sut), null);
        var properties = sut.GetProperties();
        Assert.Single(properties);
        Assert.DoesNotContain(properties, x => x.Name == "PrivateProperty");
    }
}