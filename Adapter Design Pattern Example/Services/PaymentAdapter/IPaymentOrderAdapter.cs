namespace Adapter_Design_Pattern_Example.Services.PaymentAdapter;

public interface IPaymentOrderAdapter
{
    string Pay(decimal amount, int orderId);
}