using BlazorHackerNewsClone.Services;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorHackerNewsClone
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                services.AddSingleton<HackerNewsServiceClient>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
