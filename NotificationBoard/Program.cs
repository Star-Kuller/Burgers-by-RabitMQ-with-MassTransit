using NotificationBoard;

var busControl = BusConfigurator.ConfigureBus();
await busControl.StartAsync();

try
{
    Console.WriteLine("NotificationBoard готов принимать сообщения...");
    while (true)
    {
        await Task.Delay(1000);
    }
}
finally
{
    await busControl.StopAsync();
}