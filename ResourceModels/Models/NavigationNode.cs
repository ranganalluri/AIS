using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceModels.Enums;

namespace ResourceModels.Models
{
    public class NavigationNode:HalResourceModel
    {
        public bool Current { get; set; }

        public bool CanNavigateTo { get; set; }

        public string ItemType { get; set; }
       
        public PageType NavigationNodeName { get; set; }
        
    }
}
