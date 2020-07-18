using EvolentHealthExerciseApi.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace EvolentHealthExerciseApi.Utility
{
    public class ApiUtility
    {
        public static ApiResponse<T> ApiSuccess<T>(T data)
        {
            return new ApiResponse<T>
            {
                HttpStatus = data != null  ? HttpStatusCode.OK : HttpStatusCode.NoContent,
                ResponseData = data
            };
        }
        public static ApiResponse<T> ApiError<T>(Exception ex)
        {
            ProjectLogger.Instance.GetLogger().Error(ex);
            return new ApiResponse<T>
            {
                HttpStatus = HttpStatusCode.InternalServerError,
                ResponseData = default(T)
            };
        }
        public static ApiResponse<T> ApiBadRequest<T>(string trace)
        {
            ProjectLogger.Instance.GetLogger().Trace(trace);
            return new ApiResponse<T>
            {
                HttpStatus = HttpStatusCode.BadRequest,
                ResponseData = default(T)
            };
        }
    }
}