using CoreMini.Server;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace CoreMini.Http
{
    public class HttpRequest
    {
        private readonly IHttpRequestFeature _feature;
        public Uri Url => _feature.Url;
        public NameValueCollection Headers => _feature.Headers;
        public Stream Body => _feature.Body;

        public HttpRequest(IFeatureCollection features)
        {
            _feature = features.Get<IHttpRequestFeature>();
        }
    }
}
