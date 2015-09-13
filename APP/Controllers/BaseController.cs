using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APP.Navigation;
using APP.Validators;
using FluentValidation;
using StructureMap;
using StructureMap.Attributes;
using WebGrease.Css.Extensions;

namespace APP.Controllers
{
    public class BaseController : ApiController
    {
        protected INavigation _navigation;

        private IValidator _validator;

        public BaseController(INavigation navigation)
        {
            _navigation = navigation;
        }

        protected virtual void AddLookupLinks()
        {
            
        }

        protected virtual void GetNextPage()
        {
            
        }

        protected virtual void AddResourceLinks()
        {
            
        }
        

        protected List<Errors> ValidateModel<T>(T value)
        {
            var errors = new List<Errors>();

            var factory = new MyValidationFactory(IOC.GetContainer);
            _validator = factory.GetValidator<T>();
            var result = (_validator.Validate(value));
            if (!result.IsValid)
            {
                result.Errors.ForEach(s => errors.Add(new Errors() { CtrlId = s.PropertyName, Msg = s.ErrorMessage }));
            }
            return errors;
        }
    }
}
