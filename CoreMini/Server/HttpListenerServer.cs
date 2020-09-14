using CoreMini.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoreMini.Server
{
    public class HttpListenerServer : IServer
    {
        private readonly HttpListener _httpListener;
        private readonly string[] _urls;

        public HttpListenerServer(params string[] urls)
        {
            _httpListener = new HttpListener();
            _urls = urls;
        }
        public async Task StartAsync(RequestDelegate handle)
        {
            Array.ForEach(_urls, url => _httpListener.Prefixes.Add(url));
            _httpListener.Start();

            while (true)
            {
                var listenerContext = await _httpListener.GetContextAsync();
                var feature = new HttpListenerFeature(listenerContext);
                var features = new FeatureCollection()
                    .Set<IHttpRequestFeature>(feature)
                    .Set<IHttpResponseFeature>(feature);

                var httpContext = new HttpContext(features);
                await handle(httpContext);
                listenerContext.Response.Close();
            }
        }
    }
}
