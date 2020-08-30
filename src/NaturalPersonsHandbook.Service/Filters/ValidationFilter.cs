using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NaturalPersonsHandbook.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace NaturalPersonsHandbook.Service.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage))
                    .ToArray();

                ErrorResponseModel errorResponse = new ErrorResponseModel();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        ErrorModel errorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = subError
                        };

                        errorResponse.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }

            await next();

        }
    }
}
