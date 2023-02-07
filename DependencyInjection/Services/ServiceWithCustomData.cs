namespace DependencyInjection.Services;

public class ServiceWithCustomData
{
    public string ExampleString { get; set; } = "";

    public ServiceWithCustomData(string exampleString)
    {
        ExampleString = exampleString;
    }
}