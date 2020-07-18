using EvolentHealthExerciseApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace EvolentHealthExerciseApi.Filters
{
    public class EvolentHealthExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                context.Response = context.Request.CreateResponse<ApiResponse<bool>>(HttpStatusCode.OK, new ApiResponse<bool> { HttpStatus = HttpStatusCode.NotImplemented, ResponseData = default(bool) });
            }
        }
    }
}