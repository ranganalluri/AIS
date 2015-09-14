using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APP.Navigation;
using FluentValidation;
using ResourceModels.DomainModel;

namespace APP.Common
{
    public interface IWrokflowController
    {
        INavigation GetNavigation();
        PolicyContainer GetPolicyContainer();
        IValidator GetValidator<T>();
    }
}