using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceModels.Models
{
    public class CustomerViewResource:BaseViewResource
    {
        public Customer CustomerInfo { set; get; }
    }
}
