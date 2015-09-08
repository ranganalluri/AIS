using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;
using ResourceModels.Enums;
using ResourceModels.Models;

namespace APP.Navigation
{
    public  class NavigationHelper
    {
        private static List<NavigationNode> _navigationNodes=GetAllNodes();

        public NavigationHelper()
        {
           
        }

        private static List<NavigationNode> GetAllNodes()
        {
            var nodes = new List<NavigationNode>();
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Customer });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Vehicle });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Driver });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.DriverHistoryLanding });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.DriverHistroy });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Quote });
            return nodes;
        } 
        public  NavigationNode this[PageType pageType]
        {
            get { return _navigationNodes.SingleOrDefault(node => node.NavigationNodeName == pageType); }
            set
            {
                var index = _navigationNodes.FindIndex(node => node.NavigationNodeName == pageType);
                _navigationNodes[index] = value;
            }
        }       
    }
    
}