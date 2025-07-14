using POS.Common.DTO.Common;
using POS.Common.Enums;
using POS.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace POS.Common.Utilities
{
    public static class OutputDtoConverter
    {
        public static OutputDto SetSuccess()
        {
            return new OutputDto
            {
                Status = Status.Success,
                Message = Message.Success
            };
        }

        public static OutputDto SetSuccess(string module, string operation)
        {
            string[] operations = { Operation.Save, Operation.Update, Operation.Delete };
            bool exist = operations
                         .Contains(operation);
            if (!exist)
            {
                return SetFailed($"Invalid operation {operation}");
            }

            return new OutputDto
            {
                Status = Status.Success,
                Message = $"{module} {operation} successfully.",
            };
        }

        public static OutputDto<T> SetSuccess<T>(T data)
        {
            return new OutputDto<T>
            {
                Status = Status.Success,
                Message = Message.Success,
                Data = data
            };
        }

        public static OutputDto SetFailed(string error)
        {
            return new OutputDto
            {
                Status = Status.Failed,
                Message = Message.Failed,
                Error = error
            };
        }

        public static OutputDto<T> SetFailed<T>(string error, T data)
        {
            return new OutputDto<T>
            {
                Status = Status.Failed,
                Message = Message.Failed,
                Error = error,
                Data = data
            };
        }

        public static OutputDto SetFailed(ValidationResult validationResult)
        {
            return new OutputDto
            {
                Status = Status.Failed,
                Message = Message.Failed,
                ValidationResult = validationResult
            };
        }

        public static OutputDto<T> SetFailed<T>(ValidationResult validationResult, T data)
        {
            return new OutputDto<T>
            {
                Status = Status.Failed,
                Message = Message.Failed,
                ValidationResult = validationResult,
                Data = data
            };
        }
    }
}
