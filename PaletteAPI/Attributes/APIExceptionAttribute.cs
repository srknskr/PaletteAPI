﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace PaletteAPI.Attributes
{
    public class APIExceptionAttribute:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            httpResponseMessage.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = httpResponseMessage;
            base.OnException(actionExecutedContext);
        }
    }
}   