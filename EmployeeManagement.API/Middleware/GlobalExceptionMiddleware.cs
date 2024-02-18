﻿using EmployeeManagement.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using System.Web.Http.ExceptionHandling;

namespace EmployeeManagement.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred within the application");

            var errorPayload = GenerateErrorPayload(ex);

            context.Response.StatusCode = (int)errorPayload.StatusCode;
            context.Response.ContentType = "application/json";

            var responseJson = System.Text.Json.JsonSerializer.Serialize(errorPayload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            await context.Response.WriteAsync(responseJson);
        }

        private Response GenerateErrorPayload(Exception ex)
        {
            var errorPayload = new Response();

            string errorMessage;

            if (ex is DbUpdateConcurrencyException)
            {
                errorMessage = "Data is not match, please refresh";
                errorPayload.StatusCode = (int)HttpStatusCode.Conflict; // 409 Conflict
            }
            else
            {
                errorMessage = $"We apologize but an error occured within the application, please try again later. {ex.Message}";
                errorPayload.StatusCode = (int)HttpStatusCode.InternalServerError; // 500 Internal Server Error
            }

            errorPayload.SetError(errorMessage);

            return errorPayload;
        }
    }
}
