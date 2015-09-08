using System;
using System.Collections.Generic;
using FluentValidation;
using ResourceModels.Models;
using StructureMap;
using StructureMap.Configuration.DSL;
using WebGrease.Css.Extensions;

namespace APP.Validators
{
    public class ModelCustomValidator<T> : AbstractValidator<T>
    {
        public IValidator Validator
        {
            get;
            private set;
        }
        public List<Errors> Validate1(T value)
        {

            var errors = new List<Errors>();
            //var validator = new ModelCustomValidator<T>();
            var factory = new MyValidationFactory();
            Validator = factory.GetValidator<T>();

            var result = (Validator.Validate(value));
            if (!result.IsValid)
            {
                result.Errors.ForEach(s => errors.Add(new Errors() {CtrlId = s.PropertyName, Msg = s.ErrorMessage}));
            }
            return errors;
        }
    }

    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            For<IValidator<Customer>>().Use<CustomerValidator>();
            For<IValidator<Vehicle>>().Use<VehicleValidator>();
           
        }
    }

    public class MyValidationFactory : ValidatorFactoryBase
    {        
        public override IValidator CreateInstance(Type validatorType)
        {
            return ObjectFactory.GetInstance(validatorType) as IValidator;
        }
    }
}