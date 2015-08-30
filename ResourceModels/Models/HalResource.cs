using System;
using System.Collections.Generic;

namespace ResourceModels.Models
{
    public class HalResource<T> where T:HalResourceModel
    {
        public List<BaseNode> _links { set; get; }  
        public T Resource { set; get; }
    }
    public class HalResourceModel
    {
        public NavigationResource Navigation { set; get; }

    }

    public class Link
    {
        public string href { set; get; }
        public string name { set; get; }
       
    }

    public class BaseNode
    {
        public string nodename { set; get; }
        public List<Link> _links { set; get; }
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
        public BaseNode _links { set; get; }
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