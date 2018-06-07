using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BishopTakeshi.Api.Controllers
{
    public class InvalidFormatResult : ValidationResult
    {
        protected InvalidFormatResult(ValidationResult validationResult) : base(validationResult) { }

        public InvalidFormatResult(string errorMessage) : base(errorMessage) { }

        public InvalidFormatResult(string errorMessage, IEnumerable<string> memberNames) : base(errorMessage, memberNames) { }
    }
}
