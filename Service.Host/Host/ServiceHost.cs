using System;
using Autofac;
using BishopTakeshi.Service.ConsoleHost.Host;
using MassTransit;

namespace BishopTakeshi.Service.Host.Host
{
    public class ServiceHost : MarshalByRefObject, IDisposable
    {
        private readonly IContainer container;
        private readonly IBusControl busControl;

        public ServiceHost(Func<string, string> settingsResolver)
        {
            if (settingsResolver == null) throw new ArgumentNullException(nameof(settingsResolver));

            try
            {
                var busBuilder = new BusBuilder(settingsResolver);

                this.container = busBuilder.NewContainer();
                busControl = container.Resolve<IBusControl>();
                busControl.Start();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            busControl?.Stop();
            container?.Dispose();
        }
    }
}
