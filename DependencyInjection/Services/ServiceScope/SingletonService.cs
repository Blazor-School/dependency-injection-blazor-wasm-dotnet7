namespace DependencyInjection.Services.ServiceScope;

public class SingletonService
{
    public Guid ExampleId { get; set; } = Guid.NewGuid();
}
