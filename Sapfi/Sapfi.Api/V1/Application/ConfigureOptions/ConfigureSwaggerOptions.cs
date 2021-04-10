using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace Sapfi.Api.V1.Application.ConfigureOptions
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            var xmlPath = GetXmlDocumentationPath();

            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                options.IncludeXmlComments(xmlPath);
            }
        }

        private string GetXmlDocumentationPath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            return xmlPath;
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "SAPFI API",
                Version = description.ApiVersion.ToString(),
                Description =
                @"SAPFI (Sistema de Alerta de Posição em Filas, or in English, Line Position Warning System) is a system to prevent crowding.",
                Contact = new OpenApiContact()
                {
                    Name = "SAPFI",
                    Email = "lucashmalcantara@gmail.com"
                }
            };

            if (description.IsDeprecated)
                info.Description += " [This API version has been DEPRECIATED]";

            return info;
        }
    }
}