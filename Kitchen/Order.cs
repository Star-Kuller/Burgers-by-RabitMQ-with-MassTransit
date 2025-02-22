using MassTransit;

namespace Kitchen;

[EntityName("order")]
public class Order
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public List<int> Dishes { get; set; } = [];
    public DateTime CreatedAt { get; set; }
}