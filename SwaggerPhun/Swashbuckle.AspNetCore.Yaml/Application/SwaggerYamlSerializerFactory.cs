using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Swashbuckle.AspNetCore.Swagger.Yaml
{
    class SwaggerYamlSerializerFactory
    {
        public static Serializer Create(IOptions<MvcJsonOptions> applicationJsonOptions)
        {
            var builder = new SerializerBuilder();
            builder.WithNamingConvention(new HyphenatedNamingConvention());
            builder.WithTypeInspector(innerInspector => new PropertiesIgnoreTypeInspector(innerInspector));

            return builder.Build();
        }

    }
}
