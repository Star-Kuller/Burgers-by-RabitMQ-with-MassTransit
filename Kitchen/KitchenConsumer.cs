using MassTransit;

namespace Kitchen;

public class KitchenConsumer : IConsumer<Order>
{
    private readonly Random _random = new();

    public async Task Consume(ConsumeContext<Order> context)
    {
        var order = context.Message;

        Console.WriteLine($"Начали готовить заказ {order.Id}");
        foreach (var dishId in order.Dishes)
        {
            await Task.Delay(_random.Next(500, 10000));
            Console.WriteLine($"Блюдо {dishId.GetDishName()} для заказа {order.Id} готово!");
        }

        var finishedOrder = new FinishedOrder(order)
        {
            CookingTime = DateTime.UtcNow - order.CreatedAt
        };

        Console.WriteLine($"Заказ {order.Id} готов!");
        
        await context.Publish(finishedOrder);
    }
}