using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WEB.Controllers
{
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Provides a GET pass-through
        /// </summary>
        /// <returns>The GET pass-through response</returns>
        public async Task<HttpResponseMessage> Get()
        {
            return await this.InvokeAsync(this.Request);
        }
       
        /// <summary>
        /// Provides a POST pass-through
        /// </summary>
        /// <returns>The POST pass-through response</returns>
        public async Task<HttpResponseMessage> Post()
        {
            return await this.InvokeAsync(this.Request);
        }

        /// <summary>
        /// Provides a PUT pass-through
        /// </summary>
        /// <returns>The PUT pass-through response</returns>
        public async Task<HttpResponseMessage> Put()
        {
            return await this.InvokeAsync(this.Request);
        }

        protected async Task<HttpResponseMessage> InvokeAsync(HttpRequestMessage request)
        {
            var workflowId = string.Empty;
            var cookie = System.Web.HttpContext.Current.Request.Cookies[Constants.WorkFlowId];
            if (cookie != null)
            {
                 workflowId = cookie.Value;
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49959");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("ApiHost", request.RequestUri.AbsoluteUri);
                //var path = request.RequestUri.AbsolutePath.Replace("/values","").Replace("iclicq","?key="+workflowId);
                var path = request.RequestUri.AbsolutePath.Replace("/values", "").Replace("iclicq",workflowId);
                //request.Headers.Add("host",request.RequestUri.AbsoluteUri);
                // New code:
                HttpResponseMessage response = null;
                if (request.Method == HttpMethod.Get)
                {                   
                    response = await client.GetAsync(path);
                }
                 

                if (request.Method == HttpMethod.Post)
                {
                    var data = new StringContent (await request.Content.ReadAsStringAsync());
                    data.Headers.Clear();
                    data.Headers.Add("content-type", "application/json");
                    data.Headers.Add("ApiHost", request.RequestUri.AbsoluteUri);
                    var json=Json(data);
                   
                        response = await client.PostAsync(path,data);
                }
                    
                return response;
            }
            return null;
        }
    }

    
}
