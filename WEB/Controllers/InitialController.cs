using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ResourceModels.Models;

namespace WEB.Controllers
{
    public class InitialController : Controller
    {
        // GET: api/Initial
        public async  Task<List<Link>> Index(ContextResource resource)
        {
            using (var client = new HttpClient())
            {
                var request=System.Web.HttpContext.Current.Request;
                client.BaseAddress = new Uri("http://localhost:49959");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var path = request.Url.AbsolutePath.Replace("/Intial", "");
                client.DefaultRequestHeaders.Add("ApiHost", Uri.EscapeUriString(request.Url.AbsoluteUri));
                // New code:
                var data = JsonConvert.SerializeObject(resource);
                HttpResponseMessage response = null;
                response = await client.PostAsJsonAsync("api/Initial/", new StringContent(data));
                var basenode =   await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Link>>(basenode);
            }
        }

       
    }
}
