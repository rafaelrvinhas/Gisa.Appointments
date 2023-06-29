using Appointments.Application.ViewModels.Requests;
using Appointments.Services.WorkerService;
using Appointments.Services.WorkerService.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;
using System.Text;

using IHost host = CreateHostBuilder(args).Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "AssociatePlanInfoQueue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

     var associatePlanInfo = System.Text.Json.JsonSerializer.Deserialize<AssociatePlanInfoViewModel>(message);

    services.GetRequiredService<App>().Run(associatePlanInfo);
};

channel.BasicConsume(queue: "AssociatePlanInfoQueue",
                     autoAck: true,
                     consumer: consumer);

Console.ReadLine();

IHostBuilder CreateHostBuilder(string[] strings)
{
    var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);

    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddDatabaseSetup(configurationBuilder.Build());
            services.AddAutoMapperSetup();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddDependencyInjectionSetup();
        });
}
