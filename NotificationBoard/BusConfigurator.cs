using MassTransit;
using Newtonsoft.Json;

namespace NotificationBoard;

public static class BusConfigurator
{
    public static IBusControl ConfigureBus()
    {
        return Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host("rabbitmq://rabbitmq", h =>
            {
                h.Username("guest");
                h.Password("guest");
            });
            
            cfg.ReceiveEndpoint("notification-orders", e =>
            {
                e.Consumer<OrderConsumer>();
            });
            
            cfg.ReceiveEndpoint("notification-finished_orders", e =>
            {
                e.Consumer<FinishedOrderConsumer>();
            });
            
            cfg.UseNewtonsoftJsonSerializer();
            cfg.ConfigureNewtonsoftJsonDeserializer(settings =>
            {
                settings.TypeNameHandling = TypeNameHandling.None; // Игнорировать неймспейсы
                return settings;
            });
        });
    }
}