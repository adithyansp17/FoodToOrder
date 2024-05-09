using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoodToOrder_WebAPI.Helpers
{
    public class DateOnlyJsonConverter : JsonConverter<DateTime>
    {

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
           

            return DateTime.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }
    }
    }
