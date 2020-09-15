using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] doubleArr = new double[] { 3.97, 2.82, 1.66, 0.1, 1.45 };
            float[] floatArr = new float[] { 3.97f, 2.82f, 1.66f, 0.1f, 1.45f };
            decimal[] decimalArr = new decimal[] { 3.97m, 2.82m, 1.66m, 0.1m, 1.45m };

            Console.WriteLine(doubleArr.Sum());
            Console.WriteLine(floatArr.Sum());
            Console.WriteLine(decimalArr.Sum());

            IApplicationBuilder app = new ApplicationBuilder();
            app.Use(next =>
            {
                return async context =>
                {
                    Console.WriteLine("step1");
                    context.Request += "step1=>";
                    context.Response += "step1=>";
                    await next(context);

                    Console.WriteLine("step1");
                };
            })
            .Use(next =>
            {
                return async context =>
                {
                    Console.WriteLine("step2");
                    context.Request += "step2=>";
                    context.Response += "step2=>";
                    await next(context);

                    Console.WriteLine("step1");
                };
            })
            .Use(next =>
            {
                return async context =>
                {
                    Console.WriteLine("step3");
                    context.Request += "step3=>";
                    context.Response += "step3=>";
                    await next(context);

                    Console.WriteLine("step3");
                };
            })
            .Use(next =>
            {
                return context =>
                {
                    context.Response += "end";
                    Console.WriteLine(context.Response + "end");
                    return Task.CompletedTask;
                };
            });
            var context = new Context();
            var requestDeleagte = app.Build();
            requestDeleagte(context);
            Console.WriteLine(context.Request);
            Console.WriteLine(context.Response);
        }

        private RequestDelegate Step1(RequestDelegate next)
        {
            return async context =>
            {
                Console.WriteLine("step1");

                context.Request += "step1=>";
                context.Response += "step1=>";

                await next(context);

                Console.WriteLine("step1");
            };
        }

        //public async Task Step1Context(Context context)
        //{
        //    Console.WriteLine("step1");

        //    context.Request += "step1=>";
        //    context.Response += "step1=>";

        //    await next(context);

        //    Console.WriteLine("step1");
        //}
    }
}
