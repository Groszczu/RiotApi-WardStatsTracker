using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WardStatsTracker.Core.Helpers
{
    public static class ObjectResultExtensions
    {
        public static ObjectResult AttachJsonMessage(this ObjectResult objectResult)
        {
            var modelState = objectResult.Value as ModelStateDictionary;
            var errors =
                modelState?.Values
                    .Where(s => s.Errors.Count > 0)
                    .Select(s => s.Errors);
            
            objectResult.Value = new
            {
                statusCode = objectResult.StatusCode,
                errors
            };

            return objectResult;
        }
    }
}