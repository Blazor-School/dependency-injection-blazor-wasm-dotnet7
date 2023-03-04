namespace DependencyInjection.Services;

public class DependentServiceWithParameter
{
    public string ExampleString { get; set; } = "";
    public ServiceWithParameter UpstreamService { get; set; }

    public DependentServiceWithParameter(string exampleString, ServiceWithParameter upstreamService)
    {
        ExampleString = exampleString;
        UpstreamService = upstreamService;
    }
}