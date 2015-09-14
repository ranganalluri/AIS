using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Management;
using APP.Common;
using APP.Navigation;
using APP.Validators;
using FluentValidation;
using ResourceModels.DomainModel;
using StructureMap;
using StructureMap.Attributes;
using WebGrease.Css.Extensions;

namespace APP.Controllers
{
    public class BaseController : ApiController
    {

        private IWrokflowController _wrokflowController;

        public PolicyContainer PolicyContainer
        {
            get { return this._wrokflowController.GetPolicyContainer(); }
        }

        public BaseController(IWrokflowController workFlowController)
        {
            this._wrokflowController = workFlowController;
        }

        protected virtual void AddLookupLinks()
        {
            
        }

        protected virtual void GetNextPage()
        {
            
        }

        protected virtual HttpResponseMessage HandleGet<T>(T value)
        {
            
            return null;
        }
        protected virtual HttpResponseMessage ProcessGet<T>(T value)
        {
            return null;
        }
        protected virtual HttpResponseMessage ProcessPost<T>(T value)
        {
            return null;
        }
        protected virtual HttpResponseMessage ProcessPut<T>(T value)
        {
            return null;
        }
        protected virtual HttpResponseMessage HandlePost<T>(T value)
        {
            return null;
        }
        protected virtual void AddResourceLinks()
        {
            
        }
        

        protected List<Errors> ValidateModel<T>(T value)
        {
            var errors = new List<Errors>();
           var validator =  this._wrokflowController.GetValidator<T>();
            
            //var factory = new MyValidationFactory(IOC.GetContainer);
            //_validator = factory.GetValidator<T>();

           var result = (validator.Validate(value));
            if (!result.IsValid)
            {
                result.Errors.ForEach(s => errors.Add(new Errors() { CtrlId = s.PropertyName, Msg = s.ErrorMessage }));
            }
            return errors;
        }
    }
}
