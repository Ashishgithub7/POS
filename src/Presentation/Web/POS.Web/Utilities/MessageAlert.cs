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
                string error = String.Join(Environment.NewLine, errors);
                return error;
            }

            return result.Error;
        }
    }
}
