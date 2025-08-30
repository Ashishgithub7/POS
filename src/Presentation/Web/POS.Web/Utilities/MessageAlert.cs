using Microsoft.AspNetCore.Mvc.ModelBinding;
using POS.Common.Constants;
using POS.Common.DTO.Common;

namespace POS.Web.Utilities
{
    public static class MessageAlert
    {
        public static string FailureAlert(string error)
        {
            return error;
        }

        public static string FailureAlert(OutputDto result)
        {
            if (result.ValidationResult != null)
            {
                var errors = result
                             .ValidationResult
                             .Errors
                             .Select(x => x.ErrorMessage)
                             .ToList();
                return string.Join(Environment.NewLine,errors);
            }

            return result.Error;
        }
        
        public static string FailureAlert(OutputDto result, ModelStateDictionary modelState)
        {
            if (result.ValidationResult != null)
            {
                result.ValidationResult.AddToModelState(modelState);
                return null;
            }

            return result.Error;
        }
    }
}
