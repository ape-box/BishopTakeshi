//using System;
//using Autofac;
//using BishopTakeshi.Service.ConsoleHost.Handlers;
//using MassTransit;

//namespace BishopTakeshi.Service.ConsoleHost.Host
//{
//    public class BusBuilder
//    {
//        private readonly ContainerBuilder configuredBuilder;
//        private readonly Func<string, string> settingsResolver;

//        public BusBuilder(Func<string, string> settingsResolver)
//        {
//            this.settingsResolver = settingsResolver ?? throw new ArgumentNullException(nameof(settingsResolver));
//            this.configuredBuilder = ConfigureContainerBuilder(new ContainerBuilder());
//        }

//        public IContainer NewContainer()
//        {
//            return configuredBuilder.Build();
//        }

//        private ContainerBuilder ConfigureContainerBuilder(ContainerBuilder builder)
//        {
//            RegisterMassTransit(builder);

//            builder.RegisterType<FindMatchingArticleService>()
//                .AsSelf()
//                .AsImplementedInterfaces();

//            builder.RegisterType<ValuesHandler>()
//                .AsImplementedInterfaces();

//            return builder;
//        }

//        private void RegisterMassTransit(ContainerBuilder builder)
//        {
//            var rabbitMQHost = settingsResolver("Takeshi.RabbitMq.Host");
//            var rabbitMQUser = settingsResolver("Takeshi.RabbitMq.User");
//            var rabbitMQPassword = settingsResolver("Takeshi.RabbitMq.Password");
//            var rabbitMQQueue = settingsResolver("Takeshi.RabbitMq.QueueName");

//            builder.Register(c =>
//            {
//                var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
//                {
//                    var hostObj = sbc.Host(new Uri(rabbitMQHost), h =>
//                    {
//                        h.Username(rabbitMQUser);
//                        h.Password(rabbitMQPassword);
//                    });

//                    sbc.ReceiveEndpoint(hostObj, rabbitMQQueue, ce =>
//                    {
//                        ce.PrefetchCount = 1;
//                        ce.LoadFrom(c);
//                    });
//                });

//                return bus;
//            })
//            .As<IBusControl>()
//            .As<IBus>()
//            .SingleInstance();
//        }
//    }
//}
