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
        private readonly ValidatorFactoryBase _validator;

        private readonly IPolicyContainer _policyContainer;
        public IPolicyContainer PolicyContainer
        {
            get { return _policyContainer; }
           
        }

        public WorkflowControllerContext(ValidatorFactoryBase validator,IPolicyContainer policyContainer)
        {
            _validator = validator;
            _policyContainer = policyContainer;
        }

        public INavigation GetNavigation()
        {
            throw new NotImplementedException();
        }

        public IPolicyContainer GetPolicyContainer()
        {
            throw new NotImplementedException();
        }

        public IValidator GetValidator<T>()
        {
            return _validator.GetValidator<T>();
        }
    }
}