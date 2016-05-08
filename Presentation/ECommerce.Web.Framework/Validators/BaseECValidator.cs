using FluentValidation;


namespace ECommerce.Web.Framework.Validators
{
    public  abstract class BaseECValidator<T> : AbstractValidator<T> where T : class
    {
        protected BaseECValidator()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {
            
        }
    }
}
