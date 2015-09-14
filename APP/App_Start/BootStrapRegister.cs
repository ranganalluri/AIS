using System.Threading;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using APP.Common;
using APP.Navigation;
using APP.Validators;
using FluentValidation;
using FluentValidation.Mvc;
using ResourceModels.Models;
using StructureMap;

namespace APP
{
    public class BootStrapRegister
    {
        public static void Register(IContainer container)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new StructureMapWebApiServiceActivator());
                       
            
           // container.Configure(c=>c.AddRegistry(new FluentValidationMyRegistry()));

            container.Configure(c =>
            {
               c.For<IWrokflowController>().Use<WorkflowControllerContext>();
                c.For<INavigation>().Use<BaseNode>();
                c.For<ValidatorFactoryBase>().Use<MyValidationFactory>();
               c.AddRegistry(new FluentValidationMyRegistry());
                // c.For<IValidator<Customer>>().Use<CustomerValidator>();
                //c.For<IValidator<Vehicle>>().Use<VehicleValidator>();
            });



        }
    }
}