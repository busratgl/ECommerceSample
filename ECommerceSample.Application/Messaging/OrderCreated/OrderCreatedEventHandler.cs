using DotNetCore.CAP;

namespace ECommerceSample.Application.Messaging.OrderCreated;

public class OrderCreatedEventHandler : ICapSubscribe
{
    [CapSubscribe("order.created")]
    public void Consumer(OrderCreatedEvent orderCreatedEvent)
    {
        Console.WriteLine("CreateEdilenOrder:" + orderCreatedEvent.OrderId);
    }
}