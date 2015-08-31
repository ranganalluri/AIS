using System;
using System.Collections.Generic;

namespace ResourceModels.Models
{
    public class HalResource<T> where T:HalResourceModel
    {
        
        public T Resource { set; get; }
        public List<Link> Links { set; get; }  
    }
    public class HalResourceModel
    {
        public List<Link> Links { set; get; }
        public NavigationResource Navigation { set; get; }
        public HalResourceModel()
        {
            Links=new List<Link>();
        }
       
    }

    public class Link:LinkNode
    {
        
        public string NodeName { set; get; }
       
    }

    public class LinkNode
    {
        public string Href { set; get; }
        public string Rel { set; get; }
    }

    public class NavigationResource
    {
        public INavigationResource _resource { set; get; }
    }

    public interface INavigationResource
    {
        void AddResource();
    }

    public abstract class BaserNavigationResource:INavigationResource
    {
        public LinkNode _links { set; get; }
        public string NavigationNodeName { set; get; }
        public string ItemType { set; get; }
        public string CanNavigate { set; get; }
        public void AddResource()
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerNode:BaserNavigationResource
    {
        
    }
}