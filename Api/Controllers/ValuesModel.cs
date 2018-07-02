using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BishopTakeshi.Api.Controllers
{
    public class ValuesModel
    {
        [Required]
        public IEnumerable<(string id, string[] tags)> Articles { get; set; }

        [Required]
        public IEnumerable<string> Tags { get; set; }

        [Required]
        public ServiceOperation Operation { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Articles == null || Articles.Any(HaveInvalidEntry))
            {
                yield return new ValidationResult($"A list of {nameof(Articles)} must be provided, in the form of (id, tags).", new[] { nameof(Articles) });
            }

            if (Tags == null || !Tags.Any())
            {
                yield return new ValidationResult($"A non empty list of {nameof(Tags)} must be provided.", new[] { nameof(Tags) });
            }

            if (Operation == default(ServiceOperation))
            {
                yield return new ValidationResult($"A valid {nameof(Operation)} must be provided.", new[] { nameof(Operation) });
            }
        }

        private static bool HaveInvalidEntry((string id, string[] tags) article)
            => string.IsNullOrEmpty(article.id) || article.tags == null || article.tags.Any(string.IsNullOrEmpty);
    }
}
