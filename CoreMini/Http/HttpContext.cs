using CoreMini.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMini.Http
{
    public class HttpContext
    {
        public HttpRequest Request { get; set; }
        public HttpResponse Response { get; set; }
        public HttpContext(IFeatureCollection features)
        {
            Request = new HttpRequest(features);
            Response = new HttpResponse(features);
        }
    }
}
