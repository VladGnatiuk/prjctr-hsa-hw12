using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using RabbitMQ.Client;
using System.Text;
using System;


namespace QueueApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((context, serverOptions) =>
                    {
                        int port = int.Parse(context.Configuration["PORT"] ?? "5000");
                        serverOptions.ListenAnyIP(port);
                    });
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        services.AddControllers();

                        // Register multiple Redis connections with names
                        services.AddSingleton<IRedisConnectionManager, RedisConnectionManager>();

                                    
                        var factory = new ConnectionFactory()
                        {
                            HostName = "rabbitmq",
                            UserName = "user", // Replace with your RabbitMQ username
                            Password = "password"  // Replace with your RabbitMQ password
                        };
                        var connection = factory.CreateConnection();
                        var channel = connection.CreateModel();

                        services.AddSingleton<IModel>(channel);
                        
                    });
                    webBuilder.Configure((context, app) =>
                    {
                        var env = context.HostingEnvironment;

                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }

                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                })
                .Build();

            host.Run();
        }
    }
}