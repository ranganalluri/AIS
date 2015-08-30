using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationServer.Caching;

namespace Test.asp
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        private static DataCacheFactory _cache = new DataCacheFactory();

        //private static DataCacheFactory CreateFactory()
        
        //{
        //    var config = new DataCacheFactoryConfiguration();
        //    var servers = new DataCacheServerEndpoint("Ranga-Pc",22233);
        //    config.Servers = new List<DataCacheServerEndpoint>() {servers};
        //    return new DataCacheFactory(config);
        //}

        public void ProcessRequest(HttpContext context)
        
        
        {
            context.Response.ContentType = "text/plain";
            try
            {
                var defaultCache = _cache.GetDefaultCache();

                var item = defaultCache.Get("1");

                if (item == null)
                {
                    context.Response.Write("No cache");
                    defaultCache.Add("1", "hello from cache");
                }
                else
                {
                    context.Response.Write(item);
                }
            }
            catch (Exception exception)
            {
                
                context.Response.Write(exception.Message);
            }
            

          

            
           // context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}