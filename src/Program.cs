using Autofac;
using Dioscuri.Core;

namespace Dioscuri
{
    internal class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainApp>();
            builder.RegisterType<Parser>().As<IParser>();
            builder.RegisterType<BrowserEngine>().As<IBrowserEngine>();
            builder.RegisterType<Client>().As<IClient>();
            return builder.Build();
        }

        public static void Main()  //Main entry point
        {
            CompositionRoot().Resolve<MainApp>().Run();
        }
    }
}