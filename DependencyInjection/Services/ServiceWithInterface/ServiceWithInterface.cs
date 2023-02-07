namespace DependencyInjection.Services.ServiceWithInterface;

public class ServiceWithInterface : IServiceInterface
{
    public string ExampleString { get; set; } = "Blazor School";
}
