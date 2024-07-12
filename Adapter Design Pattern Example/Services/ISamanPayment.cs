namespace Adapter_Design_Pattern_Example.Services;

public interface ISamanPayment
{
    string Pay(decimal amount, int orderId);
}


public class SamanPayment : ISamanPayment
{
    public string Pay(decimal amount, int orderId)
    {
        return $"The amount of {amount} Toman was paid through the Saman payment gateway for order {orderId}.";
    }
}