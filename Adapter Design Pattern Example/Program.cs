using Adapter_Design_Pattern_Example.Services;
using Adapter_Design_Pattern_Example.Services.PaymentAdapter;

namespace Adapter_Design_Pattern_Example;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register payment services
        builder.Services.AddScoped<IZarinPalPayment, ZarinPalPayment>();
        builder.Services.AddScoped<ISamanPayment, SamanPayment>();

        builder.Services.AddKeyedScoped<IPaymentOrderAdapter, ZarinPalPaymentAd>(PaymentGetWay.zarinpay.ToString());
        builder.Services.AddKeyedScoped<IPaymentOrderAdapter, SamanPaymentAd>(PaymentGetWay.samanpay.ToString());

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        // Map Controllers
        app.MapControllers();

        // Map minimal API endpoint
        app.MapPost("/api/payment", (PaymentModel model, IServiceProvider serviceProvider) =>
        {
            var orderPaymentService = serviceProvider.GetRequiredKeyedService<IPaymentOrderAdapter>(model.PaymentGetWay.ToString());
            var result = orderPaymentService.Pay(model.Amount, model.OrderId);
            return Results.Content(result);
        });

        app.Run();
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