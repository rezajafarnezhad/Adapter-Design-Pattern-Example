namespace Adapter_Design_Pattern_Example.Strategy_Service_sampel_2;

public interface IOrderManagementService
{
    Task<string> HandelOrder(int orderId, int userId);
}

public sealed class ProcessingOrder : IOrderManagementService
{
    public async Task<string> HandelOrder(int orderId, int userId)
    {
        await Task.Delay(2000);
        return $"OrderId: {orderId}  And  UserId: {userId} Processed";
    }
}

public sealed class RejectOrder : IOrderManagementService
{
    public async Task<string> HandelOrder(int orderId, int userId)
    {
        await Task.Delay(2000);
        return $"OrderId: {orderId}  And  UserId: {userId} Rejected";
    }
}

public sealed class DeliveredOrder : IOrderManagementService

{
    public async Task<string> HandelOrder(int orderId, int userId)
    {
        await Task.Delay(2000);
        return $"OrderId: {orderId}  And  UserId: {userId} Delivered";
    }
}