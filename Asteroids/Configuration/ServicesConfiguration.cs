using Asteroids.Core.Services;
using Microsoft.Net.Http.Headers;

namespace Asteroids.Web.Configuration;

public static class ServicesConfiguration
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        var type = typeof(IScopedService);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass && type.IsAssignableFrom(x))
            .Select(i => new { Interface = i.GetInterfaces().First(x => x.Name == $"I{i.Name}"), Class = i });

        foreach (var t in types)
        {
            _ = builder.Services.AddScoped(t.Interface, t.Class);
        }

        _ = builder.Services.AddHttpClient<INasaService, NasaService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(builder.Configuration["NasaApi:BaseAdress"]);
            httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        });
    }
}