using Moq;

using Markdown.Generator.Core.Documents;
using Markdown.Generator.Core.Markdown;
using Markdown.Generator.Core.Markdown.Elements;

namespace Markdown.Generator.Core.Tests;

public class GithubWikiDocumentBuilderTests
{
    [Fact]
    public void Generate_WithTypeArray_CallsLoadOnce()
    {
        var markdownGeneratorMock = new Mock<IMarkdownGenerator>();
        var documentBuilder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(markdownGeneratorMock.Object);
        documentBuilder.Generate(new Type[] { typeof(Link) }, "LinkWiki");
        markdownGeneratorMock.Verify(x => x.Load(It.IsAny<Type[]>()), Times.Once);
    }
    
    [Fact]
    public void Generate_WithStringParameters_CallsLoadWithStringParametersOnce()
    {
        var markdownGeneratorMock = new Mock<IMarkdownGenerator>();
        var documentBuilder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(markdownGeneratorMock.Object);
        var dllPath = "DllPath";
        var namespaceMatch = "NamespaceMatch";
        var folder = "Folder";
        documentBuilder.Generate(dllPath, namespaceMatch, folder);
        markdownGeneratorMock.Verify(x => x.Load(dllPath, namespaceMatch), Times.Once);
    }
    
    [Fact]
    public void Generate_WithAssemblyParameters_CallsLoadWithAssemblyParametersOnce()
    {
        var markdownGeneratorMock = new Mock<IMarkdownGenerator>();
        var documentBuilder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(markdownGeneratorMock.Object);
        var assemblies = new [] { typeof(Link).Assembly };
        var namespaceMatch = "NamespaceMatch";
        var folder = "Folder";
        documentBuilder.Generate(assemblies, namespaceMatch, folder);
        markdownGeneratorMock.Verify(x => x.Load(assemblies, namespaceMatch), Times.Once);
    }
}