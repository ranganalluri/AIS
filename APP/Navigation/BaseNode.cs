using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ResourceModels.DomainModel;
using ResourceModels.Enums;
using ResourceModels.Models;

namespace APP.Navigation
{
    public class BaseNode:INavigation
    {
        
        public virtual void AddNode(NavigationContext context)
        {
            
        }

        public virtual void InitialiseNodes(NavigationContext context)
        {
            var nodes = new List<NavigationNode>();
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Customer, Current = true });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Vehicle });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Driver });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.DriverHistoryLanding });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.DriverHistroy });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Quote });
            //return nodes;
        }

        public virtual NavigationNode GetCurrentNode()
        {
            return null;
        }

    }
    
}