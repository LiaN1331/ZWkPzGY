// 代码生成时间: 2025-09-16 19:30:04
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.RegularExpressions;

namespace XSSProtection
{
    public class XSSMiddleware
    {
        private readonly RequestDelegate _next;

        public XSSMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Sanitize the request body
            await SanitizeRequestBody(context.Request);

            // Continue processing the request
            await _next(context);
        }

        private async Task SanitizeRequestBody(HttpRequest request)
        {
            var body = new MemoryStream();
            await request.Body.CopyToAsync(body);
            body.Position = 0;

            using (var reader = new StreamReader(body))
            {
                string bodyContent = await reader.ReadToEndAsync();
                bodyContent = SanitizeInput(bodyContent);
                body.SetLength(0);
                await body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(bodyContent));
                request.Body = body;
            }
        }

        // Sanitizes input by removing scripts and HTML tags
        private string SanitizeInput(string input)
        {
            // Remove HTML tags
            input = Regex.Replace(input, "<[^>]*>