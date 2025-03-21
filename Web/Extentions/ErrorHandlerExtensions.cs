﻿using System.Net;
using System.Text.Json;
using Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace WebAPI.Extensions;

public static class ErrorHandlerExtensions
{
    public static void UseErrorHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature == null) return;

                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";

                context.Response.StatusCode = contextFeature.Error switch
                {
                    BadRequestException => (int)HttpStatusCode.BadRequest,
                    OperationCanceledException => (int)HttpStatusCode.ServiceUnavailable,
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                object errorResponse;

                if (contextFeature.Error is BadRequestException badRequestEx)
                {
                    errorResponse = new
                    {
                        status = badRequestEx.Status,
                        message = badRequestEx.Message,
                        errors = badRequestEx.Errors
                    };
                } else if (contextFeature.Error is NotFoundException notFoundEx)
                {
                    errorResponse = new
                    {
                        status = notFoundEx.Status,
                        message = notFoundEx.Message
                    };
                } else
                {
                    errorResponse = new
                    {
                        statusCode = context.Response.StatusCode,
                        message = contextFeature.Error.GetBaseException().Message
                    };
                }

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            });
        });
    }
}