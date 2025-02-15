using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CThub.Application.Common.Resolver;

public class PrivateResolver: DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty prop = base.CreateProperty(member, memberSerialization);
        if (!prop.Writable)
        {
            var property = member as PropertyInfo;
            bool hasPrivateSettter = property?.GetSetMethod(true) != null;
            prop.Writable = hasPrivateSettter;
        }
        
        return prop;
    }
}