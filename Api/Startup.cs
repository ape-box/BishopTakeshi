using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BishopTakeshi.Api.Filters;
using BishopTakeshi.Api.Loggers;
using BishopTakeshi.Api.Middleware;
using BishopTakeshi.Api.ServicePlugs;
using MassTransit;
using MassTransit.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BishopTakeshi.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; set; }

        private string Setting(string name)
            => Environment.GetEnvironmentVariable(name) ?? Configuration[name];

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(c =>
            {
                ApiActionFilter.ApiLogger = new ApiLogger();

                c.Filters.Add(typeof(ApiActionFilter));
                c.Filters.Add(typeof(ValidateModeltAttribute));
            });

            var builder = new ContainerBuilder();

            RegisterRabbitMQ(builder);

            builder.RegisterType<CommandIssuer>()
                .AsImplementedInterfaces();

            builder.Populate(services);

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<SomethingMiddleware>();
            app.UseMvc();

            var bus = Container.Resolve<IBusControl>();
            var busHandle = TaskUtil.Await(() => bus.StartAsync());
            lifetime.ApplicationStopping.Register(busHandle.Stop);
        }

        private void RegisterRabbitMQ(ContainerBuilder builder)
        {
            var rabbitMqHost = Setting("Takeshi.RabbitMq.Host");
            var rabbitMqUser = Setting("Takeshi.RabbitMq.User");
            var rabbitMqPassword = Setting("Takeshi.RabbitMq.Password");
            var rabbitMqQueueName = Setting("Takeshi.RabbitMq.QueueName");

            builder.Register(c =>
            {
                var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
                {
                    var host = sbc.Host(new Uri(rabbitMqHost), h =>
                    {
                        h.Username(rabbitMqUser);
                        h.Password(rabbitMqPassword);
                    });
                });

                return bus;
            })
            .As<IBusControl>()
            .SingleInstance();

            builder.Register(
                    c => c.Resolve<IBusControl>()
                        .GetSendEndpoint(
                            new Uri($"{rabbitMqHost}/{rabbitMqQueueName}")).GetAwaiter().GetResult())
                .As<ISendEndpoint>()
                .SingleInstance();
        }
    }
}
