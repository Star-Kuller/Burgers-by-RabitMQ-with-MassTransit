using MassTransit;
using Newtonsoft.Json;

namespace OrderTerminal;

public static class BusConfigurator
{
    public static IBusControl ConfigureBus()
    {
        return Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host("rabbitmq://localhost", h =>
            {
                h.Username("guest");
                h.Password("guest");
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