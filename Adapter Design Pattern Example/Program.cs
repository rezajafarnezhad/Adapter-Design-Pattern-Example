using Adapter_Design_Pattern_Example.Controllers;
using Adapter_Design_Pattern_Example.Services;
using Adapter_Design_Pattern_Example.Services.PaymentAdapter;
using Adapter_Design_Pattern_Example.Strategy_Service_sampel_2;

namespace Adapter_Design_Pattern_Example;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IZarinPalPayment, ZarinPalPayment>();
        builder.Services.AddScoped<ISamanPayment, SamanPayment>();

        builder.Services.AddKeyedScoped<IPaymentOrderAdapter, ZarinPalPaymentAd>(PaymentGetWay.zarinpay.ToString());
        builder.Services.AddKeyedScoped<IPaymentOrderAdapter, SamanPaymentAd>(PaymentGetWay.samanpay.ToString());


        ///Version 2
        builder.Services.AddScoped<IOrderManagementFactory, OrderManagementFactory>();
        builder.Services.AddKeyedScoped<IOrderManagementService, ProcessingOrder>(OrderStatus.Processing);
        builder.Services.AddKeyedScoped<IOrderManagementService, DeliveredOrder>(OrderStatus.Delivered);
        builder.Services.AddKeyedScoped<IOrderManagementService, RejectOrder>(OrderStatus.Rejected);


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}