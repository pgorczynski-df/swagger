using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

namespace Swashbuckle.AspNetCore.Swagger.Yaml
{
    public class PropertiesIgnoreTypeInspector : TypeInspectorSkeleton
    {
        private readonly ITypeInspector _typeInspector;

        public PropertiesIgnoreTypeInspector(ITypeInspector typeInspector)
        {
            _typeInspector = typeInspector;
        }

        public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
        {
            return _typeInspector.GetProperties(type, container)
                .Where(p => p.Name != "extensions" && p.Name != "operation-id");
        }
    }
}