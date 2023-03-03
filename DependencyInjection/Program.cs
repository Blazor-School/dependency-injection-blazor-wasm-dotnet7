using DependencyInjection;
using DependencyInjection.Services;
using DependencyInjection.Services.AutoRegisteredServices.Interfaces;
using DependencyInjection.Services.ServiceScope;
using DependencyInjection.Services.ServiceWithInterface;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSingleton<SingletonService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddTransient<TransientService>();
builder.Services.AddTransient<IServiceInterface, ServiceWithInterface>();
builder.Services.AddTransient<ServiceWithParameter>(serviceProvider => new("Blazor School"));
builder.Services.AddTransient<DependentService>(serviceProvider => new(serviceProvider.GetRequiredService<ServiceWithParameter>()));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
ScanAndRegisterServices(builder.Services);

await builder.Build().RunAsync();

static void ScanAndRegisterServices(IServiceCollection services)
{
    var currentAssembly = Assembly.GetExecutingAssembly();
    var allTypes = currentAssembly.GetTypes().Concat(
        currentAssembly
        .GetReferencedAssemblies()
        .SelectMany(assemblyName => Assembly.Load(assemblyName).GetTypes()))
        .Where(type => !type.IsInterface && !type.IsAbstract);

    var scopedServices = allTypes.Where(type => typeof(IScopedService).IsAssignableFrom(type));

    foreach (var type in scopedServices)
    {
        services.AddScoped(type);
    }

    var transientServices = allTypes.Where(type => typeof(ITransientService).IsAssignableFrom(type));

    foreach (var type in transientServices)
    {
        services.AddTransient(type);
    }

    var singletonServices = allTypes.Where(type => typeof(ISingletonService).IsAssignableFrom(type));

    foreach (var type in singletonServices)
    {
        services.AddTransient(type);
    }
}