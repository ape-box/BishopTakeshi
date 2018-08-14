//using System;
//using Autofac;
//using MassTransit;

//namespace BishopTakeshi.Service.ConsoleHost.Host
//{
//    public class ServiceHost : MarshalByRefObject, IDisposable
//    {
//        private readonly IContainer container;
//        private readonly IBusControl busControl;

//        public ServiceHost(Func<string, string> settingsResolver)
//        {
//            if (settingsResolver == null) throw new ArgumentNullException(nameof(settingsResolver));

//            try
//            {
//                var busBuilder = new BusBuilder(settingsResolver);

//                this.container = busBuilder.NewContainer();
//                busControl = container.Resolve<IBusControl>();
//                busControl.Start();
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }

//        public void Dispose()
//        {
//            busControl?.Stop();
//            container?.Dispose();
//        }
//    }
//}
