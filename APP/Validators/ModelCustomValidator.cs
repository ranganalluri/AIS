using System;
using System.Collections.Generic;
using APP.Navigation;
using FluentValidation;
using ResourceModels.Models;
using StructureMap;
using StructureMap.Configuration.DSL;
using WebGrease.Css.Extensions;

namespace APP.Validators
{
    public class ModelCustomValidator<T> : AbstractValidator<T>
    {
       
       
    }

    public class FluentValidationMyRegistry : Registry
    {
        public FluentValidationMyRegistry()
        {
            For<IValidator<Customer>>().Use<CustomerValidator>();
            For<IValidator<Vehicle>>().Use<VehicleValidator>();
            //For<INavigation>().Use<BaseNode>();

        }
    }

    public class MyValidationFactory : ValidatorFactoryBase
    {
        private readonly IContainer _container;
        public MyValidationFactory(IContainer container)
        {
            this._container = container;
        }
        public MyValidationFactory()
        {
          
        }
        public override IValidator CreateInstance(Type validatorType)
        {
            return (IValidator)_container.GetInstance(validatorType);
            //  return ObjectFactory.GetInstance(validatorType) as IValidator;
        }
    }
}