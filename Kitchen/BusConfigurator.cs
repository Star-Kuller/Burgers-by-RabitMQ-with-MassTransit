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
                e.UseFilter(new LoggingFilter<Order>());
                e.Consumer<KitchenConsumer>();
            });
            
            cfg.UseNewtonsoftJsonSerializer();
            cfg.ConfigureNewtonsoftJsonDeserializer(settings =>
            {
                settings.TypeNameHandling = TypeNameHandling.None; // Игнорировать неймспейсы
                return settings;
            });
        });
        return bus;
    }
}

public class LoggingFilter<T> : IFilter<ConsumeContext<T>> where T : class
{
    public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
    {
        // Логируем входящее сообщение
        Console.WriteLine($"Получено сообщение: {context.Message}");

        // Передаем управление следующему фильтру или потребителю
        await next.Send(context);
    }

    public void Probe(ProbeContext context)
    {
        context.CreateFilterScope("logging-filter");
    }
}