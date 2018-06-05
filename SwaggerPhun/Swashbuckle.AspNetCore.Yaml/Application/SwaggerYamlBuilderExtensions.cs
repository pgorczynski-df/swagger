using System;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.Swagger.Yaml;

namespace Microsoft.AspNetCore.Builder
{
    public static class SwaggerYamlBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerYaml(
            this IApplicationBuilder app,
            Action<SwaggerOptions> setupAction = null)
        {
            var options = new SwaggerOptions();
            setupAction?.Invoke(options);

            return app.UseMiddleware<SwaggerYamlMiddleware>(options);
        }
    }
}