using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApplication1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class InfoMiddleware
    {
        IRatingBL _ratingBL;

        private readonly RequestDelegate _next;

        public InfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingBL _ratingBL)
        {
            DateTime date = DateTime.Now;
            Rating rating = new Rating()
            {
                Host = httpContext.Request.Host.ToString(),
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                Referer = httpContext.Request.Headers["Referer"].ToString(),
                UserAgent = httpContext.Request.Headers["User-Agent"].ToString(),
                RecordDate = date
            };
            await _ratingBL.postRating(rating);
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class InfoMiddlewareExtensions
    {
        public static IApplicationBuilder UseInfoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InfoMiddleware>();
        }
    }
}
