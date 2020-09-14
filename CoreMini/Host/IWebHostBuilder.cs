using CoreMini.Http;
using CoreMini.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMini.Host
{
    public interface IWebHostBuilder
    {
        IWebHostBuilder UseServer(IServer server);
        IWebHostBuilder Configure(Action<IApplicationBuilder> configure);
        IWebHost Build();
    }
}
