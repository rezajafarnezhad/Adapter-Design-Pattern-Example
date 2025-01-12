using Adapter_Design_Pattern_Example.Services.PaymentAdapter;
using Adapter_Design_Pattern_Example.Strategy_Service_sampel_2;
using Microsoft.AspNetCore.Mvc;

namespace Adapter_Design_Pattern_Example.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController: ControllerBase
{
    private readonly IOrderManagementFactory _orderManagementFactory;
    public OrderController(IOrderManagementFactory orderManagementFactory)
    {
        _orderManagementFactory = orderManagementFactory;
    }

    [HttpPost("OrderManagement")]
    public async Task<IActionResult> OrderManagement(OrderStatus orderStatus , int userId , int orderId)
    {
        var orderMenagement =  _orderManagementFactory.GetOrderManagementService(orderStatus);
        var data = await orderMenagement.HandelOrder(orderId, userId);
        return Content(data);
    }
    
}