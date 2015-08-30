using FluentValidation;
using ResourceModels.Models;

namespace DataAccess.Validators
{
    public class CustomerValidator : ModelCustomValidator<Customer>
    {
       
        
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().Length(10, 15);
           
        }

        //public override ValidationResult Validate(Customer instance)
        //{
        //    RuleFor(c => c.Name).NotEmpty().Length(10, 15);
        //    return base.Validate(instance);
        //}
    }

    //public class ModelCustomValidator1<T>
    //{
        
       
    //    public List<Errors> Validate1(T value)
    //    {
            
    //        var errors = new List<Errors>();
    //        //var validator = new ModelCustomValidator<T>();
    //        var name = typeof (T).Name;
    //        Type type = Type.GetType("DataAccess.Validators."+name+"Validator, DataAccess");

    //        // create an instance of that type
    //        var validator = (IValidator)Activator.CreateInstance(type,true);
           
    //        var result = (validator.Validate(value));
    //        if (!result.IsValid)
    //        {
    //            result.Errors.ForEach(s => errors.Add(new Errors() { CtrlId = s.PropertyName, Msg = s.ErrorMessage }));
    //        }
    //        return errors;
    //    }
    //}
}