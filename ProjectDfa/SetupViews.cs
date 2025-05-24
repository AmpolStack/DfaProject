using ProjectDfa.Custom;

namespace ProjectDfa;

public static class SetupViews
{
    private static readonly IEnumerable<ViewRouteComponent> Components = new List<ViewRouteComponent>
    {
        new() { Endpoint = "/home", Directory = "wwwroot/index.html", ContentType = "text/html" },
        new() { Endpoint = "/home/styles", Directory = "wwwroot/style.css", ContentType = "text/css" },
        new() { Endpoint = "/home/common", Directory = "wwwroot/common.css", ContentType = "text/css" },
        new() { Endpoint = "/regex", Directory = "wwwroot/Regex/index.html", ContentType = "text/html" },
        new() { Endpoint = "/regex/styles", Directory = "wwwroot/Regex/style.css", ContentType = "text/css" },
        new() { Endpoint = "regex/script", Directory = "wwwroot/Regex/script.js", ContentType = "text/javascript" },
    };

    public static void MapComponents(this WebApplication app, string currentDirectory)
    {
        foreach (var component in Components)
        {
            app.MapGet(component.Endpoint, async (CancellationToken ct) =>
            {
                
                var parts = component.Directory.Split("/", StringSplitOptions.RemoveEmptyEntries);
                
                //This method is used for compatibility with Windows (use '\') and Linux (use '/')
                var subPath = Path.Combine(parts);
                var path = Path.Combine(currentDirectory, subPath);
                
                if (!File.Exists(path))
                {
                    return Results.NotFound("Component not found");
                }

                var content = await File.ReadAllTextAsync(path, cancellationToken: ct);
                return Results.Content(content, component.ContentType);
            });
        }
    }
}
