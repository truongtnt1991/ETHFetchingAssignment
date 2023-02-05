using FetchData;
using FetchData.BackgroundTasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
{
    services.AddServices();
    services.BuildServiceProvider();
}).Build().Run();

