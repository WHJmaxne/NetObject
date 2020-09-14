using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreMini.Http
{
    public delegate Task RequestDelegate(HttpContext context);

    public interface IApplicationBuilder
    {
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);
        RequestDelegate Build();
    }
}
