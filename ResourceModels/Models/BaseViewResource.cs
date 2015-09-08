using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceModels.Enums;

namespace ResourceModels.Models
{
    public class BaseViewResource:HalResourceModel
    {
        public List<NavigationNode> Navigation { set; get; }
        public UserType UserType { set; get; }
        public string Lob { set; get; }
    }
}
