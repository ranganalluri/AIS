using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APP.Navigation;
using FluentValidation;
using ResourceModels.DomainModel;

namespace APP.Common
{
    public class WorkflowControllerContext:IWrokflowController
    {
        private ValidatorFactoryBase _validator;
        public WorkflowControllerContext(ValidatorFactoryBase validator)
        {
            _validator = validator;
        }

        public INavigation GetNavigation()
        {
            throw new NotImplementedException();
        }

        public PolicyContainer GetPolicyContainer()
        {
            throw new NotImplementedException();
        }

        public IValidator GetValidator<T>()
        {
            return _validator.GetValidator<T>();
        }
    }
}