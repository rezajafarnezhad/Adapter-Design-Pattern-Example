namespace Adapter_Design_Pattern_Example.Services.PaymentAdapter;

public class ZarinPalPaymentAd : IPaymentOrderAdapter
{
    private readonly IZarinPalPayment _zarinPalPayment;
    public ZarinPalPaymentAd(IZarinPalPayment zarinPalPayment)
    {
        _zarinPalPayment = zarinPalPayment;
    }
    public string PayOrder(decimal amount, int orderId)
    {
        return _zarinPalPayment.Pay(amount, orderId);
    }
}