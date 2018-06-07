using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BishopTakeshi.Api.Controllers
{
    public class InvalidSyntaxResult : ValidationResult
    {
        protected InvalidSyntaxResult(ValidationResult validationResult) : base(validationResult) { }

        public InvalidSyntaxResult(string errorMessage) : base(errorMessage) { }

        public InvalidSyntaxResult(string errorMessage, IEnumerable<string> memberNames) : base(errorMessage, memberNames) { }
    }
}
