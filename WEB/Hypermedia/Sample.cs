using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace WEB.Hypermedia
{
    public class Sample
    {
        public static readonly string ConfigurationMethodName = "Register";
        public static readonly string ConfigClassName = "WebApiConfig";
        public static readonly string HelpPageConfigClassName = "HelpPageConfig";

        public static void LoadAssembly()
        {
            //var assembly = typeof(Sample).Assembly;
            //Type webApiConfigType = assembly.GetTypes().FirstOrDefault(t => t.Name == "WebApiConfig");
            //if (webApiConfigType == null)
            //{
            //    throw new InvalidOperationException(string.Format("Cannot find the configuration class: '{0}' in {1}", ConfigClassName, ""));
            //}
            //MethodInfo registerConfigMethod = webApiConfigType.GetMethod(ConfigurationMethodName, BindingFlags.Static | BindingFlags.Public);
            //if (registerConfigMethod == null)
            //{
            //    throw new InvalidOperationException(string.Format("Cannot find the static configuration method: '{0}()' in {1}", ConfigurationMethodName, ConfigClassName));
            //}
            //Action<HttpConfiguration> registerConfig = Delegate.CreateDelegate(typeof(Action<HttpConfiguration>), registerConfigMethod) as Action<HttpConfiguration>;
            //HttpConfiguration config = new HttpConfiguration();
            //registerConfig(config);
           

        }

    }
}