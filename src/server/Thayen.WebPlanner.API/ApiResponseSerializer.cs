using System.Text.Json;
using System.Text.Json.Serialization;

namespace Thayen.WebPlanner.API;

public class ApiResponseSerializer : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsAssignableTo(typeof(ApiResponse));
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return options.GetConverter(typeToConvert);
    }
}