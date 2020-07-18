﻿using EvolentHealthExerciseApi.Models;
using EvolentHealthExerciseApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EvolentHealthExerciseApi.Filters
{
    public class ValidateModel : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                List<string> errorCollestion = new List<string>();
                var states = actionContext.ModelState.ToList();
                foreach (var item in states)
                {
                    var errores = item.Value.Errors;
                    foreach (var error in errores )
                    {
                        errorCollestion.Add(error.ErrorMessage);
                    }
                }
                string message = String.Join("|", errorCollestion.ToArray());

                actionContext.Response = actionContext.Request.CreateResponse<ApiResponse<bool>>(HttpStatusCode.OK, ApiUtility.ApiBadRequest<bool>(message));

            }

        }

    }
}