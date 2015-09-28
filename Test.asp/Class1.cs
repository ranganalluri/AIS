using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Test.Caching
{
    public  class Class1
    {
        public static void GetResponse(Task<WebResponse> webrequesTask)
        {
            if (HttpContext.Current.Session == null) 
            {
                Debug.Write("Session is null");
            }
            var responseValue = string.Empty;
            if (webrequesTask.Exception != null)
            {
                Debug.Write(webrequesTask.Exception.InnerException.Message);
            }
            else
            {
                var resposne =(HttpWebResponse) webrequesTask.Result;
                
                using (var responseStream = resposne.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }
            }
            if (!string.IsNullOrEmpty(responseValue))
            {
                Debug.Write(responseValue);
            }
        }

        public static void GetResponse(WebResponse webrequesTask)
        {
            var responseValue = string.Empty;
            var resposne = (HttpWebResponse)webrequesTask;

            using (var responseStream = resposne.GetResponseStream())
            {
                if (responseStream != null)
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseValue = reader.ReadToEnd();
                    }
            }
            if (!string.IsNullOrEmpty(responseValue))
            {
                Debug.Write(responseValue);
            }
        }
        public static async Task<int> TestDealyTask()
        {
            //await Task.Delay(TimeSpan.FromSeconds(10));//.ConfigureAwait(false);
            return await Task.FromResult(1);
        }

        public static void TestDealy()
        {
            CallHomeSite();
           // await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
           // test.Wait();
            // test.ContinueWith(t => { });

           // return await Task.FromResult(1);

        }

        public static  void CallHomeSite()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:11684/PayPlanService.svc/GetGlToken");

                request.Method = "Get";
                //request.Cont6eA1   1R ntLength = 0;
                request.ContentType = "application/json";

                var response = request.GetResponseAsync();
               // GetResponse(response);
                 response.ContinueWith(Class1.GetResponse);
            }
            catch (Exception exception)
            {

                throw;
            }
           
        }

    }
}