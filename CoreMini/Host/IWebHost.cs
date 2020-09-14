using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreMini.Host
{
    public interface IWebHost
    {
        Task StartAsync();
    }
}
