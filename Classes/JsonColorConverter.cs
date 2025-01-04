using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExileMaps.Classes;

public class JsonColorConverter : JsonConverter<Color>
{
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string colorString = reader.GetString();
        return ParseColor(colorString);
    }

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
    {
        string colorString = $"{value.R}, {value.G}, {value.B}, {value.A}";
        writer.WriteStringValue(colorString);
    }

    private Color ParseColor(string colorString)
    {
        try
        {
            var parts = colorString.Split(',');
            if (parts.Length == 4)
            {
                int r = int.Parse(parts[1].Trim());
                int g = int.Parse(parts[2].Trim());
                int b = int.Parse(parts[3].Trim());
                int a = int.Parse(parts[0].Trim());
                return Color.FromArgb(a, r, g, b);
            }
            else
            {
                throw new ArgumentException("Invalid color format");
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error parsing color: {colorString}", ex);
        }
    }
}