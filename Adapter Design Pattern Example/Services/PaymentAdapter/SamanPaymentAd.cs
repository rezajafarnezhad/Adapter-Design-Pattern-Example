namespace Adapter_Design_Pattern_Example.Services.PaymentAdapter;

public class SamanPaymentAd : IPaymentOrderAdapter
{
    private readonly ISamanPayment _samanPayment;
    public SamanPaymentAd(ISamanPayment samanPayment)
    {
        _samanPayment = samanPayment;
    }

    public string Pay(decimal amount, int orderId)
    {
        return _samanPayment.Pay(amount, orderId);
    }
}