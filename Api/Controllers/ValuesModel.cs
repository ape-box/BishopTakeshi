using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BishopTakeshi.Api.Controllers
{
    public class ValuesModel
    {
        [Required]
        public IEnumerable<string> ValuesToSum { get; set; }

        internal IEnumerable<int> ValuesToSumAsIntegers
            => ValuesToSum.Select(int.Parse);

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ValuesToSum == null)
            {
                yield return new InvalidSyntaxResult(
                    "A list of values must be provided, empty list is fine.",
                    new[] { nameof(ValuesToSum) });
            }
            else if (ValuesToSum.Select(t => !int.TryParse(t, out var value)).Any())
            {
                yield return new InvalidFormatResult(
                    "Values must be integers.",
                    new[] { nameof(ValuesToSum) });
            }
        }
    }
}
