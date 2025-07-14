using FluentValidation.Results;
using POS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.DTO.Common
{
    public class OutputDto
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public string Error { get; set; }
    }

    public class OutputDto<T> : OutputDto
    {
        public T Data { get; set; }
    }
}
