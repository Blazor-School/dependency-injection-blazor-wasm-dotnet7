namespace DependencyInjection.Services;

public class ServiceWithParameter
{
    public string ExampleString { get; set; } = "";

    public ServiceWithParameter(string exampleString)
    {
        ExampleString = exampleString;
    }
}