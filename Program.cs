using Microsoft.Extensions.DependencyInjection.Extensions;
using Scriban.Runtime;
using Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ITemplateLoader, TemplateLoader>();
builder.Services.AddScoped<Page>();

var app = builder.Build();

app.MapGet("/", async (Page p) =>
{
    var page = await p.Render(
        "home",
        new ScriptObject {{ "title", "Home" }}
    );

    return Results.Text(page, "text/html");
});

app.MapGet("/teams", async (Page p) =>
{
    var page = await p.Render(
        "teams",
        new ScriptObject {{ "title", "Teams" }}
    );

    return Results.Text(page, "text/html");
});

app.Run();



