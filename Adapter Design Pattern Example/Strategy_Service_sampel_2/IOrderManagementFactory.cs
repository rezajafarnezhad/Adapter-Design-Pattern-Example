namespace Adapter_Design_Pattern_Example.Strategy_Service_sampel_2;

public interface IOrderManagementFactory
{
    IOrderManagementService GetOrderManagementService(OrderStatus status);
}


public class OrderManagementFactory : IOrderManagementFactory
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public OrderManagementFactory(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public IOrderManagementService GetOrderManagementService(OrderStatus status)
    {
        return _serviceScopeFactory
            .CreateScope()
            .ServiceProvider
            .GetRequiredKeyedService<IOrderManagementService>(status);
    }
}

public enum OrderStatus
{
    Processing,
    Rejected,
    Delivered,
}