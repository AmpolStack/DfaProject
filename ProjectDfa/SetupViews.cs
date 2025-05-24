using ProjectDfa.Custom;

namespace ProjectDfa;

public static class SetupViews
{
    public static void MapComponents(this WebApplication app,
        string currentDirectory,
        List<ViewRouteComponent> components)
    {
        foreach (var component in components)
        {
            app.MapGet(component.Endpoint, async (CancellationToken ct) =>
            {
                
                var parts = component.DirectoryPath.Split("/", StringSplitOptions.RemoveEmptyEntries);
                
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
