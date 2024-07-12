using Adapter_Design_Pattern_Example.Services.PaymentAdapter;
using Microsoft.AspNetCore.Mvc;

namespace Adapter_Design_Pattern_Example.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{

    public readonly IServiceProvider _ServiceProvider;
    public PaymentController(IServiceProvider serviceProvider)
    {
        _ServiceProvider = serviceProvider;
    }

    [HttpPost("payment")]
    public IActionResult PaymentOrder([FromBody] PaymentModel model)
    {
        var orderPaymentService = _ServiceProvider.GetRequiredKeyedService<IPaymentOrderAdapter>(model.PaymentGetWay.ToString());
        var result = orderPaymentService.Pay(model.Amount, model.OrderId);
        return Content(result);
    }
}



public class PaymentModel
{
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public PaymentGetWay PaymentGetWay { get; set; }
}


public enum PaymentGetWay
{
    zarinpay,
    samanpay
}