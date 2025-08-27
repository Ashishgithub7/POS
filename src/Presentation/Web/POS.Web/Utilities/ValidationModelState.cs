using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace POS.Web.Utilities
{
    public static class ValidationModelState
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState) 
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
