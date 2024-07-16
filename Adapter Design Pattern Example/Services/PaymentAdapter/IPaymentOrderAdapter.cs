namespace Adapter_Design_Pattern_Example.Services.PaymentAdapter;

public interface IPaymentOrderAdapter
{
    string PayOrder(decimal amount, int orderId);
}