using MassTransit;

namespace NotificationBoard;

[EntityName(nameof(Order))]
[MessageUrn(nameof(Order))]
public class Order
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public List<int> Dishes { get; set; } = [];
    public DateTime CreatedAt { get; set; }
}