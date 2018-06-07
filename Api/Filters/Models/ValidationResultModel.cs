using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BishopTakeshi.Api.Filters.Models
{
    public class ValidationResultModel
    {
        public const string ValidationFailedMessage = "Validation Failed";

        public string Message { get; }
        public List<ValidationError> Errors { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = ValidationFailedMessage;
            Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(t => new ValidationError(key, t.ErrorMessage)))
                .ToList();
        }
    }
}
