using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APP.Common;
using APP.Processors;
using ResourceModels.DomainModel;
using ResourceModels.Enums;
using ResourceModels.Models;

namespace APP.Builders
{
    public class CustomerBuilder:IBaseBuilder<CustomerViewResource>
    {

        public CustomerViewResource Build(PolicyContainer container)
        {
            var returnvalue = new CustomerViewResource();
            if (container != null && container.Customer != null)
            {
                returnvalue.CustomerInfo = container.Customer;
            }
            else
            {
                returnvalue.CustomerInfo = new Customer();
            }
           
            return returnvalue;
        }
    }
}