using Microsoft.Extensions.DependencyInjection;
using System;

namespace _03CatDI
{
    class Program
    {
        static void Main(string[] args)
        {



            //Cat cat = new Cat().Register<IFoo, Foo>()
            //.Register<IBar, Bar>()
            //.Register<IBaz, Baz>()
            //.Register<IQux, Qux>();

            //IFoo service = cat.GetService<IFoo>();
            //Foo foo = (Foo)service;
            //Baz baz = (Baz)foo.Baz;

            //Console.WriteLine("cat.GetService<IFoo>(): {0}", service);
            //Console.WriteLine("cat.GetService<IFoo>().Bar: {0}", foo.Bar);
            //Console.WriteLine("cat.GetService<IFoo>().Baz: {0}", foo.Baz);
            //Console.WriteLine("cat.GetService<IFoo>().Baz.Qux: {0}", baz.Qux);


            IServiceCollection services = new ServiceCollection()
            .AddSingleton<IFoo, Foo>()
            .AddSingleton<IBar>(new Bar())
            .AddSingleton<IBaz>(_ => new Baz())
            .AddSingleton<IQux, Qux>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            Console.WriteLine("serviceProvider.GetService<IFoo>(): {0}", serviceProvider.GetService<IFoo>());
            Console.WriteLine("serviceProvider.GetService<IBar>(): {0}", serviceProvider.GetService<IBar>());
            Console.WriteLine("serviceProvider.GetService<IBaz>(): {0}", serviceProvider.GetService<IBaz>());
            Console.WriteLine("serviceProvider.GetService<IGux>(): {0}", serviceProvider.GetService<IQux>());
        }
    }
}
