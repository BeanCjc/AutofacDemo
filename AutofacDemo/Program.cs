using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using Autofac;

namespace AutofacDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var builder=new ContainerBuilder();
            builder.RegisterType<A1>().AsSelf().As<IA>();
            builder.RegisterType<B1>().As<IB>();
            builder.RegisterType<B2>().AsSelf().As<IB>().IfNotRegistered(typeof(B2));


            var container = builder.Build();
            using (var scope=container.BeginLifetimeScope())
            {
                var a1 = scope.Resolve<A1>();
                var aiInterface = scope.Resolve<IA>();
                var b1 = scope.Resolve<IB>();
                var b2 = scope.Resolve<B2>();
                var b2Interface = scope.Resolve<IB>();
                a1.Write();
                aiInterface.Write();
                b1.Write();
                b2.Write();
                b2Interface.Write();
            }
            Console.ReadKey();
        }
    }
}
