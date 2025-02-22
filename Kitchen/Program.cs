using Kitchen;

var busControl = BusConfigurator.ConfigureBus();
await busControl.StartAsync();

try
{
    Console.WriteLine("Кухня готова принимать заказы...");
    while (true)
    {
        await Task.Delay(1000);
    }
}
finally
{
    await busControl.StopAsync();
}