using MassTransit;

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
        });
    }
}