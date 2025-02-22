using MassTransit;

namespace NotificationBoard;

public class OrderConsumer : IConsumer<Order>
{
    public async Task Consume(ConsumeContext<Order> context)
    {
        var order = context.Message;
        Console.WriteLine($"Поступил заказ {order.OrderNumber}");
    }
}