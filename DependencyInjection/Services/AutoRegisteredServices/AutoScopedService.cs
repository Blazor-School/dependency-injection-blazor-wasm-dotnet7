using DependencyInjection.Services.AutoRegisteredServices.Interfaces;

namespace DependencyInjection.Services.AutoRegisteredServices;

public class AutoScopedService : IScopedService
{
    public Guid ExampleId { get; set; } = Guid.NewGuid();
}
