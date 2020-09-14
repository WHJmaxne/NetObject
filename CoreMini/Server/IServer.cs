using CoreMini.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreMini.Server
{
    public interface IServer
    {
        Task StartAsync(RequestDelegate handle);
    }
}
