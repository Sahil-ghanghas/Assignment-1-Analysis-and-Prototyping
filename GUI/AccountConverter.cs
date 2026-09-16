using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GUI
{
    public class AccountConverter : JsonConverter<Account>
    {
        public override Account Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                if (root.TryGetProperty("AccountType", out JsonElement typeElement))
                {
                    string accountType = typeElement.GetString();
                    
                    if (accountType == "Everyday")
                        return JsonSerializer.Deserialize<EverydayAccount>(root.GetRawText(), options);
                    if (accountType == "Investment")
                        return JsonSerializer.Deserialize<InvestmentAccount>(root.GetRawText(), options);
                    if (accountType == "Omni")
                        return JsonSerializer.Deserialize<OmniAccount>(root.GetRawText(), options);
                }
                
                // Fallback or old format
                return JsonSerializer.Deserialize<EverydayAccount>(root.GetRawText(), options);
            }
        }

        public override void Write(Utf8JsonWriter writer, Account value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            
            // Add a discriminator property so we know what type to deserialize back into
            if (value is EverydayAccount)
                writer.WriteString("AccountType", "Everyday");
            else if (value is InvestmentAccount)
                writer.WriteString("AccountType", "Investment");
            else if (value is OmniAccount)
                writer.WriteString("AccountType", "Omni");

            // Serialize the rest of the properties using reflection or just serializing the object itself
            // We serialize the actual object type to get its specific properties
            using (JsonDocument document = JsonSerializer.SerializeToDocument(value, value.GetType(), options))
            {
                foreach (var property in document.RootElement.EnumerateObject())
                {
                    property.WriteTo(writer);
                }
            }
            
            writer.WriteEndObject();
        }
    }
}
