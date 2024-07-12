namespace Adapter_Design_Pattern_Example.Services;

public interface IZarinPalPayment
{
    string Pay(decimal amount, int orderId);
}


public class ZarinPalPayment : IZarinPalPayment
{
    public string Pay(decimal amount, int orderId)
    {
        return $"The amount of {amount} Toman was paid through the ZarinPal payment gateway for order {orderId}.";
    }
}

