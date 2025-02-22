using MassTransit;

namespace NotificationBoard;

public class FinishedOrderConsumer: IConsumer<FinishedOrder>
{
    public async Task Consume(ConsumeContext<FinishedOrder> context)
    {
        var order = context.Message;
        Console.WriteLine($"Заказ {order.OrderNumber} готов! Приготовлен за {order.CookingTime}");
        Console.WriteLine($"Можете забирать {string.Join(", ", order.Dishes)}");
    }
}