using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class WorkFlowContext
    {
        public string Url { set; get; }
        public WorkFlowContext(string url)
        {
            this.Url = url;            
        }
    }
}