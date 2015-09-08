using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Helpers;
using Newtonsoft.Json;
using ResourceModels.Models;

namespace APP.Hypermedia
{
    public class JsonHalMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        public JsonHalMediaTypeFormatter()
        {
            base.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/hal+json"));
        }

        public override bool CanReadType(Type type)
        {
            return true;
            //return type.BaseType == typeof(HalResourceModel) ||
            //  type.BaseType.GetGenericTypeDefinition() == typeof(HalResourceList<>);
        }

        public override bool CanWriteType(Type type)
        {
            return true;
            //return type.BaseType == typeof(HalResourceModel) ||
            //  type.BaseType.GetGenericTypeDefinition() == typeof(HalResourceList<>);
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            var sb = new StringBuilder();
            var stringWriter = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter((TextWriter) new StreamWriter(writeStream)))
            {
                writer.WriteStartObject();
                WriteJsonModel(writer, value, type, null);

                writer.WriteEndObject();
            }
        }

        private void WriteJsonModel(JsonWriter writer, object value, Type type, string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {

                writer.WritePropertyName("_embeded");
                writer.WriteValue("");
                // writer.WriteStartArray();
            }
            //else if(type.BaseType==typeof(HalResourceModel))
            //{
            //    writer.WritePropertyName(propertyName);
            //    writer.WriteValue("");
            //    writer.WritePropertyName("_embeded");
            //    writer.WriteValue("");
            //    foreach (var proerties in type.GetProperties())
            //    {
            //        object obj1 = proerties.GetValue(value);
            //        if (obj1 == null)
            //        {
            //            writer.WritePropertyName(proerties.Name);

            //            writer.WriteValue(obj1);
            //            continue;

            //        }
            //        if (obj1.GetType() == typeof(List<Link>))
            //        {
            //            writer.WritePropertyName("_link");
            //            writer.WriteValue("");
            //            foreach (var pro1 in obj1.GetType().GetProperties())
            //            {
            //                if (pro1.GetType() == typeof(Link))
            //                {


            //                }
            //            }
            //        }

            //    }
            //}

            foreach (var proerties in type.GetProperties())
            {
                if (proerties.MemberType.GetType() == typeof (System.Object))
                {

                }
                //object obj1 = proerties.GetValue(value);
                //if (obj1 == null)
                //{
                //    writer.WritePropertyName(proerties.Name);

                //    writer.WriteValue(obj1);
                //    continue;

                //}
                // if (obj1.GetType() == typeof(List<Link>)){
                //{
                //    writer.WritePropertyName("_link");
                //    writer.WriteValue("");
                //    foreach (var pro1 in obj1.GetType().GetProperties())
                //    {
                //        if (pro1.GetType() == typeof(Link))
                //        {


                //        }
                //    }
            }

            if (value.GetType() == typeof (HalResourceModel))
            {
                writer.WritePropertyName("_embeded");
                writer.WriteValue("");
            }

            // WriteJsonModel(writer,obj1,obj1.GetType(),proerties.Name);
        }

        // writer.WriteEnd();

    


public override object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger,
            CancellationToken cancellationToken)
        {
            return base.ReadFromStream(type, readStream, content, formatterLogger, cancellationToken);
        }       
    }
}