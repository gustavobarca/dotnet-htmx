using Scriban;
using Scriban.Runtime;

namespace Utils;

public class Page(IHttpContextAccessor httpContextAccessor, ITemplateLoader templateLoader)
{
    private readonly IHttpContextAccessor _httpContext = httpContextAccessor!;
    private readonly ITemplateLoader templateLoader = templateLoader;

    public async Task<string> Render(string page, ScriptObject values)
    {
        if (_httpContext.HttpContext == null) throw new Exception("Could not process your request");

        if (_httpContext.HttpContext.Request.Headers["hx-request"] == "true")
            values.Add("useLayout", false);
        else
            values.Add("useLayout", true);

        var c = new TemplateContext { TemplateLoader = templateLoader };
        c.PushGlobal(values);

        var file = await File.ReadAllTextAsync($"Pages/{page}.html");

        return Template.Parse(file).Render(c);
    }
}