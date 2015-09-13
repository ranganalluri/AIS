using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResourceModels.DomainModel;
using ResourceModels.Enums;
using ResourceModels.Models;

namespace APP.Navigation
{
    public class NavigationContext
    {
        private List<NavigationNode> _navigationNodes = GetAllNodes();

        private PageType pageType;
        private PolicyContainer policyContainer;

        public NavigationNode this[PageType pageType]
        {
            get { return _navigationNodes.SingleOrDefault(node => node.NavigationNodeName == pageType); }
            set
            {
                var index = _navigationNodes.FindIndex(node => node.NavigationNodeName == pageType);
                _navigationNodes[index] = value;
            }
        }

        public virtual void InitialiseNodes()
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
        private static List<NavigationNode> GetAllNodes()
        {
            var nodes = new List<NavigationNode>();
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Customer, Current = true });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Vehicle });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Driver });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.DriverHistoryLanding });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.DriverHistroy });
            nodes.Add(new NavigationNode() { NavigationNodeName = PageType.Quote });
            return nodes;
        } 
    }
}