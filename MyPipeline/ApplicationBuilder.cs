using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPipeline
{
    public interface IApplicationBuilder
    {
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);
        RequestDelegate Build();
    }
    public class ApplicationBuilder : IApplicationBuilder
    {
        private List<Func<RequestDelegate, RequestDelegate>> _middlewares = new List<Func<RequestDelegate, RequestDelegate>>();

        public RequestDelegate Build()
        {
            //RequestDelegateBuild = RequestDelegateContextBuild;
            return DelegateBuild;
        }

        private Task DelegateBuild(Context context)
        {
            _middlewares.Reverse();
            RequestDelegate next = c => { c.Request = "none"; c.Response = "none"; return Task.CompletedTask; };
            foreach (var middleware in _middlewares)
            {
                next = middleware(next);
            }
            return next(context);
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }
    }
}
