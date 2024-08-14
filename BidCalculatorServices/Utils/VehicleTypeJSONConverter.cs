using System.Text.Json;
using System.Text.Json.Serialization;
using BidCalculatorServices.DTOs.enums;

public class VehicleTypeConverter : JsonConverter<VehicleType>
{
    public override VehicleType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        if (Enum.TryParse(typeof(VehicleType), value, true, out var result))
        {
            return (VehicleType)result;
        }

        throw new JsonException($"Unable to convert \"{value}\" to {nameof(VehicleType)}.");
    }

    public override void Write(Utf8JsonWriter writer, VehicleType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToLower());
    }
}
