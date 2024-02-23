using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;

namespace Utils;

public class TemplateLoader : ITemplateLoader
{
    public ValueTask<string> LoadAsync(TemplateContext context, SourceSpan callerSpan, string templatePath) => new(File.ReadAllTextAsync(templatePath));
    public string GetPath(TemplateContext context, SourceSpan callerSpan, string templateName) => Path.Combine(Environment.CurrentDirectory, templateName);
    public string Load(TemplateContext context, SourceSpan callerSpan, string templatePath) => File.ReadAllText(templatePath);
}