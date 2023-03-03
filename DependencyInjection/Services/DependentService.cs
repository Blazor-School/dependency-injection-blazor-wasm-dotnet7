namespace DependencyInjection.Services;

public class DependentService
{
    public ServiceWithParameter ServiceWithCustomData { get; set; }

    public DependentService(ServiceWithParameter serviceWithCustomData)
    {
        ServiceWithCustomData = serviceWithCustomData;
    }
}