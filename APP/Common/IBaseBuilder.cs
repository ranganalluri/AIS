using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using ResourceModels.DomainModel;
using ResourceModels.Models;

namespace APP.Common
{
    public interface IBaseBuilder
    {
        BaseViewResource Build(PolicyContainer container);
    }
}