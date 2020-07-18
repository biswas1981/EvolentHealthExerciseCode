﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace EvolentHealthExerciseApi.Models
{
    public class ApiResponse<T>
    {
        public HttpStatusCode HttpStatus { get; set; }
        public T ResponseData { get; set; }

    }
}