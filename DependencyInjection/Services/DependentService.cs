namespace DependencyInjection.Services;

public class DependentService
{
    public ServiceWithParameter UpstreamService { get; set; }

    public DependentService(ServiceWithParameter upstreamService)
    {
        UpstreamService = upstreamService;
    }
}