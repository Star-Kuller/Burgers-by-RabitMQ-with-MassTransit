using MassTransit;
using Newtonsoft.Json;

namespace Kitchen;

public static class BusConfigurator
{
    public static IBusControl ConfigureBus()
    {
        var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host("rabbitmq://rabbitmq", h =>
            {
                h.Username("guest");
                h.Password("guest");
            });
            
            cfg.ReceiveEndpoint("kitchen", e =>
            {
                e.Consumer<KitchenConsumer>();
            });
        });
        return bus;
    }
}