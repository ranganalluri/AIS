using System;
using System.Collections;
using System.Collections.Generic;

namespace ResourceModels.Models
{
    public class HalResourceList<T> where T:HalResourceModel, IEnumerable<T>,IEnumerable
    {
        
        public List<T> Resources { set; get; }
        public List<Link> Links { set; get; }  

    }
    public class HalResourceModel
    {
        public string Rel { get; set; }

        public string Href { get; set; }

        public string LinkName { get; set; }

        public List<Link> Links { set; get; }
        
        public HalResourceModel()
        {
            Links=new List<Link>();
        }
       
    }

}